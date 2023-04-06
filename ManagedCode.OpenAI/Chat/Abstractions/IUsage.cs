namespace ManagedCode.OpenAI.Chat;

public interface IUsage
{
    public int PromptTokens { get; }

    public int CompletionTokens { get; }

    public int TotalTokens { get; }
}