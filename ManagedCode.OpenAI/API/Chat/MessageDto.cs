using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

public class MessageDto
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}