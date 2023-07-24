using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public class ChatSessionRecord : IChatSessionRecord
{
    public required RoleType Role { get; set; }
    public required string Content { get; set; }
}