using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public static class ChatExtensions
{
    public static Task<IAnswer<IChatMessage>> AskAsync(this IOpenAiChat chat, string message,
        Func<IChatMessageParametersBuilder, IChatMessageParameters> parameters)
    {
        var builder = new ChatMessageParametersBuilder();
        return chat.AskAsync(message, parameters.Invoke(builder));
    }

    public static Task<IAnswer<IChatMessage[]>> AskMultipleAsync(this IOpenAiChat chat,
        string message, int countOfAnswers,
        Func<IChatMessageParametersBuilder, IChatMessageParameters> parameters)
    {
        var builder = new ChatMessageParametersBuilder();
        return chat.AskMultipleAsync(message, countOfAnswers, parameters.Invoke(builder));
    }
}