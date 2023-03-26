using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal class ModelsResponseDto
{
    [JsonPropertyName("data")]
    public ModelDto[] Models { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }
}