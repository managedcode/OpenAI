

using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats;

public class Message
{
    [JsonPropertyName("role")]
    public string Role;

    [JsonPropertyName("content")]
    public string Content;
    
    public Message(string role, string content)
    {
        Role = role;
        Content = content;
    }
}