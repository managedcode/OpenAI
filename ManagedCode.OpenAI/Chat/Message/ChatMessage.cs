using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

internal class ChatMessage : IChatMessage
{
    public required string Content { get; set; }
    public required RoleType Role { get; set; }

    public required string FinishReason { get; set; }
}