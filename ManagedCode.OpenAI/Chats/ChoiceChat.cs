using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats;

public class ChoiceChat
{
    [JsonPropertyName("index")]
    public int Index;

    [JsonPropertyName("message")]
    public Message Message;

    [JsonPropertyName("finish_reason")]
    public string FinishReason;
}