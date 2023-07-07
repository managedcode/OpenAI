using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Client;

public class DefaultGptClientConfiguration : IGptClientConfiguration
{
    private const GptModel DEFAULT_MODEL = GptModel.Gpt35Turbo;

    public DefaultGptClientConfiguration()
    {
        ModelId = DEFAULT_MODEL.Name();
    }

    public string ModelId { get; set; }
}