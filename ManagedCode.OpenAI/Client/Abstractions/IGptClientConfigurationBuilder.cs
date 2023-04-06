namespace ManagedCode.OpenAI.Client;

public interface IGptClientConfigurationBuilder
{
    IGptClientConfigurationBuilder SetDefaultModel(string modelId);
    IGptClientConfigurationBuilder SetDefaultModel(GptModel model);

    IGptClientConfiguration Build();
}