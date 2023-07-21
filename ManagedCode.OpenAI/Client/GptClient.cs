using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client;

public class GptClient : IOpenAIClient
{
    private IOpenAiWebClient _webClient = null!;
    
    public GptClient(string apiKey)
    {
        Init(apiKey, default, new DefaultOpenAiClientConfiguration());
    }

    public GptClient(string apiKey, IOpenAiClientConfiguration configuration)
    {
        Init(apiKey, default, configuration);
    }

    public GptClient(string apiKey, string organization)
    {
        Init(apiKey, organization, new DefaultOpenAiClientConfiguration());
    }

    public GptClient(string apiKey, string organization, IOpenAiClientConfiguration configuration)
    {
        Init(apiKey, organization, configuration);
    }


    internal GptClient(string apiKey, IOpenAiClientConfiguration configuration, string? organization)
    {
        Init(apiKey, organization, configuration);
    }

    internal GptClient(IOpenAiClientConfiguration configuration, IOpenAiWebClient webClient)
    {
        _webClient = webClient;
        Configuration = new DefaultOpenAiClientConfiguration();
        ImageClient = new ImageClient(_webClient);
        Configuration = configuration;
    }

    private GptClient()
    {
    }


    public IOpenAiClientConfiguration Configuration { get; private set; } = null!;
    public IImageClient ImageClient { get; private set; } = null!;

    public void Configure(IOpenAiClientConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(Func<IOpenAiClientConfigurationBuilder, IOpenAiClientConfiguration> configuration)
    {
        var builder = new OpenAiClientConfigurationBuilder();
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

    public IOpenAiChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session)
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

    private void Init(string apiKey, string? organization, IOpenAiClientConfiguration configuration)
    {
        var webClient = string.IsNullOrWhiteSpace(organization)
            ? new OpenAiWebClient(apiKey)
            : new OpenAiWebClient(apiKey, organization);

        _webClient = webClient;
        Configuration = configuration;
        ImageClient = new ImageClient(_webClient);
    }
}
