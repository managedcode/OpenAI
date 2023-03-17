using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Chats;

public class ChoiceChat
{
    [JsonProperty("index")]
    public int Index;

    [JsonProperty("message")]
    public Message Message;

    [JsonProperty("finish_reason")]
    public string FinishReason;
}