using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Client;

public class OpenAiClientConfigurationBuilder : IOpenAiClientConfigurationBuilder
{
    private readonly DefaultOpenAiClientConfiguration _configuration;

    public OpenAiClientConfigurationBuilder()
    {
        _configuration = new DefaultOpenAiClientConfiguration();
    }

    public IOpenAiClientConfigurationBuilder SetDefaultModel(string modelId)
    {
        _configuration.ModelId = modelId;
        return this;
    }

    public IOpenAiClientConfigurationBuilder SetDefaultModel(GptModel model)
    {
        _configuration.ModelId = model.Name();
        return this;
    }

    public IOpenAiClientConfiguration Build()
    {
        return _configuration;
    }
}