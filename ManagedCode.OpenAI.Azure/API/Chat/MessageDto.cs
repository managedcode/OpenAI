using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal class MessageDto
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}