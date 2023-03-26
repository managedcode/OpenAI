namespace ManagedCode.OpenAI.Chat
{
    public interface IChatSessionRecord
    {
        string Role { get; }
        string Content { get; }
    }
}
