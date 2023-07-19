namespace ManagedCode.OpenAI.Client;

public interface IGptClientBuilder
{
    public IGptClientBuilder WithOrganization(string organization);

    public IGptClientBuilder Configure(Action<IGptClientConfigurationBuilder> configuration);

    public IOpenAIClient Build();
}