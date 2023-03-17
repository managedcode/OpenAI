using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Chats;

public class Message
{
    [JsonProperty("role")]
    public string Role;

    [JsonProperty("content")]
    public string Content;
    
    public Message(string role, string content)
    {
        Role = role;
        Content = content;
    }
}