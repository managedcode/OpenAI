using Azure.AI.OpenAI;

namespace ManagedCode.OpenAI.Azure.Client;

public interface IAzureOpenAiConfigurationBuilder
{
    IAzureOpenAiConfigurationBuilder SetDefaultModel(string gptModel);

    ChatCompletionsOptions Build();
}