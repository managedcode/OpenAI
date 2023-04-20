using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client;

public class GptClient : IGptClient
{
    private IOpenAiWebClient _webClient = null!;

    public GptClient(string apiKey)
    {
        Init(apiKey, default, new DefaultGptClientConfiguration());
    }

    public GptClient(string apiKey, IGptClientConfiguration configuration)
    {
        Init(apiKey, default, configuration);
    }

    public GptClient(string apiKey, string organization)
    {
        Init(apiKey, organization, new DefaultGptClientConfiguration());
    }

    public GptClient(string apiKey, string organization, IGptClientConfiguration configuration)
    {
        Init(apiKey, organization, configuration);
    }


    internal GptClient(string apiKey, IGptClientConfiguration configuration, string? organization)
    {
        Init(apiKey, organization, configuration);
    }

    internal GptClient(IGptClientConfiguration configuration, IOpenAiWebClient webClient)
    {
        _webClient = webClient;
        Configuration = new DefaultGptClientConfiguration();
        ImageClient = new ImageClient(_webClient);
        Configuration = configuration;
    }

    private GptClient()
    {
    }


    public IGptClientConfiguration Configuration { get; private set; } = null!;
    public IImageClient ImageClient { get; private set; } = null!;

    public void Configure(IGptClientConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(Func<IGptClientConfigurationBuilder, IGptClientConfiguration> configuration)
    {
        var builder = new GptClientConfigurationBuilder();
        Configure(configuration.Invoke(builder));
    }

    public async Task<IModel[]> GetModelsAsync()
    {
        var models = await _webClient.ModelsAsync();
        return models.Models.Select(x => x.ToModel()).ToArray();
    }

    public async Task<IModel> GetModelAsync(string modelId)
    {
        var model = await _webClient.ModelAsync(modelId);
        return model.ToModel();
    }

    public IGptChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session)
    {
        return new GptChat(_webClient, session, defaultMessageParameters);
    }

    public ICompletionBuilder Completion(string prompt)
    {
        return new CompletionsBuilder(_webClient, prompt);
    }

    public IEditBuilder Edit(string input, string instruction)
    {
        return new EditBuilder(_webClient, input, instruction);
    }

    public IModerationBuilder Moderation()
    {
        return new ModerationBuilder(_webClient);
    }

    public static IGptClientBuilder Builder(string apiKey)
    {
        return new GptClientBuilder(apiKey);
    }

    private void Init(string apiKey, string? organization, IGptClientConfiguration configuration)
    {
        var webClient = string.IsNullOrWhiteSpace(organization)
            ? new OpenAiWebClient(apiKey)
            : new OpenAiWebClient(apiKey, organization);

        _webClient = webClient;
        Configuration = configuration;
        ImageClient = new ImageClient(_webClient);
    }
}
