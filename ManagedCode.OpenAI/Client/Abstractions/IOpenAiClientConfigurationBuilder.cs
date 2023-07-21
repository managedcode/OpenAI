namespace ManagedCode.OpenAI.Client;

public interface IOpenAiClientConfigurationBuilder
{
    IOpenAiClientConfigurationBuilder SetDefaultModel(string modelId);
    IOpenAiClientConfigurationBuilder SetDefaultModel(GptModel model);

    IOpenAiClientConfiguration Build();
}