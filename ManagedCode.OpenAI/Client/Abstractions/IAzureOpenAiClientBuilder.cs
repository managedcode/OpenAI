using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client;

public interface IAzureOpenAiClientBuilder
{
    public IAzureOpenAiClientBuilder Configure(ChatCompletionsOptions options);
    public IOpenAIClient Build();
}