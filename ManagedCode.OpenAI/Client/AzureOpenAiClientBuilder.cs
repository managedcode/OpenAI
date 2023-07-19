using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client;

public class AzureOpenAiClientBuilder : IAzureOpenAiClientBuilder
{
    private AzureOpenAIChat _chat;
    private OpenAIClient _client;
    private ChatCompletionsOptions _options;

    public IAzureOpenAiClientBuilder InitializateClient(Uri uri, AzureKeyCredential credential)
    {
        _client = new OpenAIClient(uri, credential);
        return this;
    }
    
    public IAzureOpenAiClientBuilder Configure(ChatCompletionsOptions options)
    {
        _options = options;
        return this;
    }

    public AzureOpenAIChat Build()
    {
        return new AzureOpenAIChat(_client, _options);
    }
}