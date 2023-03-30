using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal class ModerationRequestDto
{
    [JsonPropertyName("input")]
    public List<string> Input { get; set; } = new List<string>();

    [JsonPropertyName("model")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Model { get; set; }
}