using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Client;

public class DefaultOpenAiClientConfiguration : IOpenAiClientConfiguration
{
    private const GptModel DEFAULT_MODEL = GptModel.Gpt35Turbo;

    public DefaultOpenAiClientConfiguration()
    {
        ModelId = DEFAULT_MODEL.Name();
    }

    public string ModelId { get; set; }
}