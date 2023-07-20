namespace ManagedCode.OpenAI.Client;

public class GptClientBuilder : IGptClientBuilder
{

    public GptClientBuilder(string apiKey)
    {
        ApiKey = apiKey;
        Configuration = new DefaultGptClientConfiguration();
    }

    protected string ApiKey { get; set; }
    protected IGptClientConfiguration Configuration { get; set; }
    protected string? Organization { get; set; }

    public IGptClientBuilder WithOrganization(string organization)
    {
        Organization = organization;
        return this;
    }

    public IGptClientBuilder Configure(Action<IGptClientConfigurationBuilder> configuration)
    {
        var builder = new GptClientConfigurationBuilder();
        configuration.Invoke(builder);
        Configuration = builder.Build();
        return this;
    }

    public virtual IOpenAIClient<IGptClientConfiguration, IGptClientConfigurationBuilder> Build()
    {
        var client = new GptClient(ApiKey, Configuration, Organization);
        return client;
    }
}