using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Azure.Chat;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Azure.Client;

public class AzureOpenAiClientBuilder : IAzureOpenAiClientBuilder
{
    private OpenAIClient Client;
    protected IOpenAiClientConfiguration Configuration { get; set; }

    public AzureOpenAiClientBuilder(Uri uri, AzureKeyCredential credential)
    {
        Client = new OpenAIClient(uri, credential);
    }

    public IAzureOpenAiClientBuilder Configure(Action<IOpenAiClientConfigurationBuilder> configuration)
    {
        var builder = new OpenAiClientConfigurationBuilder();
        configuration.Invoke(builder);
        Configuration = builder.Build();
        return this;
    }

    public IOpenAIClient Build()
    {
        return new AzureOpenAiClient(Client, Configuration);
    }
}