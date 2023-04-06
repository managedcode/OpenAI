using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Client;

public class GptClientConfigurationBuilder : IGptClientConfigurationBuilder
{
    private readonly DefaultGptClientConfiguration _configuration;

    public GptClientConfigurationBuilder()
    {
        _configuration = new DefaultGptClientConfiguration();
    }

    public IGptClientConfigurationBuilder SetDefaultModel(string modelId)
    {
        _configuration.ModelId = modelId;
        return this;
    }

    public IGptClientConfigurationBuilder SetDefaultModel(GptModel model)
    {
        _configuration.ModelId = model.Name();
        return this;
    }

    public IGptClientConfiguration Build()
    {
        return _configuration;
    }
}