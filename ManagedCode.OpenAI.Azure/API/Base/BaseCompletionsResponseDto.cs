using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal abstract class BaseCompletionsResponseDto<TChoiceModel>
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("choices")]
    public List<TChoiceModel> Choices { get; set; }

    [JsonPropertyName("usage")]
    public UsageDto Usage { get; set; }
}