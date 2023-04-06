namespace ManagedCode.OpenAI.Client;

public class GptClientBuilder : IGptClientBuilder
{
    private readonly string _apiKey;
    private IGptClientConfiguration _configuration = new DefaultGptClientConfiguration();
    private string? _organization;

    public GptClientBuilder(string apiKey)
    {
        _apiKey = apiKey;
    }

    public IGptClientBuilder WithOrganization(string organization)
    {
        _organization = organization;
        return this;
    }

    public IGptClientBuilder Configure(Action<IGptClientConfigurationBuilder> configuration)
    {
        var builder = new GptClientConfigurationBuilder();
        configuration.Invoke(builder);

        _configuration = builder.Build();
        return this;
    }

    public GptClient Build()
    {
        var client = new GptClient(_apiKey, _configuration, _organization);
        return client;
    }
}