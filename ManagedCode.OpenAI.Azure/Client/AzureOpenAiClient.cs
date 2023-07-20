using System.Security.Cryptography;
using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client;

public class AzureOpenAiClient : IOpenAIClient<ChatCompletionsOptions, ChatCompletionsOptions>
{
    private OpenAIClient _client;
    private ChatCompletionsOptions _options;
    
    public ChatCompletionsOptions Configuration { get; private set; } = null!;
    public IImageClient ImageClient { get; }
    
    public AzureOpenAiClient(OpenAIClient client, ChatCompletionsOptions options)
    {
        _client = client;
        Configuration = options; //hard code
    }
    
    public void Configure(ChatCompletionsOptions configuration)
    {
        throw new NotImplementedException();
    }

    public void Configure(Func<ChatCompletionsOptions, ChatCompletionsOptions> configuration)
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