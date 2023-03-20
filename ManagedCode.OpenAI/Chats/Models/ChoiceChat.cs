using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats;

public class ChoiceChat
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("message")]
    public Message Message { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}