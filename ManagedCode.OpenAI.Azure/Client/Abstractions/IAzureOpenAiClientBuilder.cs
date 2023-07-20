using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Azure.Client;

public interface IAzureOpenAiClientBuilder
{
    public IAzureOpenAiClientBuilder Configure(ChatCompletionsOptions options);
    public IOpenAIClient<ChatCompletionsOptions, IAzureOpenAiConfigurationBuilder> Build();
}