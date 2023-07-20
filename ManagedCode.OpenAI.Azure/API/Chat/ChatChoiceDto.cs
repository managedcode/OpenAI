using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal class ChatChoiceDto
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("message")]
    public MessageDto Message { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}