

using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Azure.Chat;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Azure.Client;

public class AzureOpenAiClient : IOpenAIClient
{
    private OpenAIClient _client;
    public IOpenAiClientConfiguration Configuration { get; }
    public IImageClient ImageClient { get; }
    
    public AzureOpenAiClient(OpenAIClient client, IOpenAiClientConfiguration options)
    {
        _client = client;
        Configuration = options;
    }
    
    public void Configure(IOpenAiClientConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public void Configure(Func<IOpenAiClientConfigurationBuilder, IOpenAiClientConfiguration> configuration)
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

    public IOpenAiChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session)
    {
        return new AzureOpenAIChat(_client, Configuration, defaultMessageParameters, session);
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