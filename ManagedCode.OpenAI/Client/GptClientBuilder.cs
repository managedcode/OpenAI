namespace ManagedCode.OpenAI.Client;

public class GptClientBuilder : IGptClientBuilder
{

    public GptClientBuilder(string apiKey)
    {
        ApiKey = apiKey;
        Configuration = new DefaultOpenAiClientConfiguration();
    }

    protected string ApiKey { get; set; }
    protected IOpenAiClientConfiguration Configuration { get; set; }
    protected string? Organization { get; set; }

    public IGptClientBuilder WithOrganization(string organization)
    {
        Organization = organization;
        return this;
    }

    public IGptClientBuilder Configure(Action<IOpenAiClientConfigurationBuilder> configuration)
    {
        var builder = new OpenAiClientConfigurationBuilder();
        configuration.Invoke(builder);
        Configuration = builder.Build();
        return this;
    }

    public virtual IOpenAIClient Build()
    {
        var client = new GptClient(ApiKey, Configuration, Organization);
        return client;
    }
}