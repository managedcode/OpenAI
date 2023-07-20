using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client;

public class AzureOpenAiClient : IOpenAIClient
{
    private OpenAIClient _client;
    private ChatCompletionsOptions _options;
    
    public IGptClientConfiguration Configuration { get; private set; } = null!;
    public IImageClient ImageClient { get; }
    
    public AzureOpenAiClient(OpenAIClient client, ChatCompletionsOptions options)
    {
        _client = client;
        _options = options;
        Configuration = new DefaultGptClientConfiguration(){ModelId = "12"}; //hard code
    }
    
    public void Configure(IGptClientConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public void Configure(Func<IGptClientConfigurationBuilder, IGptClientConfiguration> configuration)
    {
        throw new NotImplementedException();
    }

    public Task<IModel[]> GetModelsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IModel> GetModelAsync(string modelId)
    {
        throw new NotImplementedException();
    }

    public IOpenAiChat OpenChat(IChatMessageParameters defaultMessageParameters = null, IChatSession session = null)
    {
        return new AzureOpenAIChat(_client, _options);
    }

    public ICompletionBuilder Completion(string prompt)
    {
        throw new NotImplementedException();
    }

    public IEditBuilder Edit(string input, string instruction)
    {
        throw new NotImplementedException();
    }

    public IModerationBuilder Moderation()
    {
        throw new NotImplementedException();
    }

    public static IAzureOpenAiClientBuilder Builder(Uri uri, AzureKeyCredential credential)
    {
        return new AzureOpenAiClientBuilder(uri, credential);
    }
}