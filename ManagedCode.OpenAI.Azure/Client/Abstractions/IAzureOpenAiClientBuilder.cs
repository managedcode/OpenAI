using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Azure.Client;

public interface IAzureOpenAiClientBuilder
{
    public IAzureOpenAiClientBuilder Configure(Action<IOpenAiClientConfigurationBuilder> configuration);
    public IOpenAIClient Build();
}