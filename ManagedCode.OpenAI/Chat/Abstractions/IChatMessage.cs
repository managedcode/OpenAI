using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public interface IChatMessage
{
    public string Content { get; }
    public RoleType Role { get; }
    public string FinishReason { get; set; }
}