namespace ManagedCode.OpenAI.Chat;

public interface IAzureOpenAIChat
{
    public Task<string> AskAsync(string message);

    public Task<string> AskAsync(string message, IChatMessageParameters parameters);

    public Task<string> AskMultipleAsync(string message, int countOfAnswers);

    public Task<string> AskMultipleAsync(string message, int countOfAnswers,
        IChatMessageParameters parameters);
}