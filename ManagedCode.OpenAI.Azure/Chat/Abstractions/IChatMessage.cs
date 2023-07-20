namespace ManagedCode.OpenAI.Chat;

public interface IChatMessage
{
    public string Content { get; }
    public string Role { get; }
    public string FinishReason { get; set; }
}