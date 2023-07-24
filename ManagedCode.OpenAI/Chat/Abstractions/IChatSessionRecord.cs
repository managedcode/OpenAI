using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public interface IChatSessionRecord
{
    RoleType Role { get; }
    string Content { get; }
}