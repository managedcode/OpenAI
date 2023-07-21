

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
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public void Configure(Func<IOpenAiClientConfigurationBuilder, IOpenAiClientConfiguration> configuration)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public Task<IModel[]> GetModelsAsync()
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public Task<IModel> GetModelAsync(string modelId)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public IOpenAiChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session)
    {
        return new AzureOpenAIChat(_client, Configuration, defaultMessageParameters, session);
    }

    public ICompletionBuilder Completion(string prompt)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public IEditBuilder Edit(string input, string instruction)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public IModerationBuilder Moderation()
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public static IAzureOpenAiClientBuilder Builder(Uri uri, AzureKeyCredential credential)
    {
        return new AzureOpenAiClientBuilder(uri, credential);
    }
}