namespace ManagedCode.OpenAI.Chat;

internal class ChatSessionRecord : IChatSessionRecord
{
    public required string Role { get; set; }
    public required string Content { get; set; }
}