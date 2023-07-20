using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Azure.Chat;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Azure.Client;

public class AzureOpenAiClientBuilder : IAzureOpenAiClientBuilder
{
    private AzureOpenAIChat _chat;
    private OpenAIClient _client;
    private ChatCompletionsOptions _options;
    public AzureOpenAiClientBuilder(Uri uri, AzureKeyCredential credential)
    {
        _client = new OpenAIClient(uri, credential);
        _options = new ChatCompletionsOptions
        {
            MaxTokens = 400,
            Temperature = 1f,
            FrequencyPenalty = 0.0f,
            PresencePenalty = 0.0f,
            NucleusSamplingFactor = 0.95f // Top P
        };
    }
    
    public IAzureOpenAiClientBuilder Configure(ChatCompletionsOptions options)
    {
        _options = options;
        return this;
    }

    public IOpenAIClient Build()
    {
        return new AzureOpenAiClient(_client, _options);
    }
}