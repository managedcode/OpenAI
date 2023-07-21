namespace ManagedCode.OpenAI.Client;

public interface IGptClientBuilder
{
    public IGptClientBuilder WithOrganization(string organization);

    public IGptClientBuilder Configure(Action<IOpenAiClientConfigurationBuilder> configuration);

    public IOpenAIClient Build();
}