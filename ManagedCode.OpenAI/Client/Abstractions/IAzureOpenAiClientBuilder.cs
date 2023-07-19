using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client;

public interface IAzureOpenAiClientBuilder
{
    public IAzureOpenAiClientBuilder InitializateClient(Uri uri, AzureKeyCredential credential);
    public IAzureOpenAiClientBuilder Configure(ChatCompletionsOptions options);
    public AzureOpenAIChat Build();
}