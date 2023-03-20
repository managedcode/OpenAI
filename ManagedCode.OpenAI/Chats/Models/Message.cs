

using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;

namespace ManagedCode.OpenAI.Chats;

public class Message
{
    [JsonPropertyName("role")]
    public RoleType Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
    
    public Message(RoleType role, string content)
    {
        Role = role;
        Content = content;
    }
}