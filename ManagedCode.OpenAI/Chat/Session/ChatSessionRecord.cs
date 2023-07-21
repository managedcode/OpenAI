namespace ManagedCode.OpenAI.Chat;

public class ChatSessionRecord : IChatSessionRecord
{
    public required string Role { get; set; }
    public required string Content { get; set; }
}