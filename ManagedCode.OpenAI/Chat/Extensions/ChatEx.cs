using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat.Extensions
{
    public static class ChatEx
    {
        public static Task<IAnswer<IChatMessage>> AskAsync(this IGptChat chat, string message,
            Func<IChatMessageParametersBuilder, IChatMessageParameters> parameters)
        {
            var builder = new ChatMessageParametersBuilder();
            return chat.AskAsync(message, parameters.Invoke(builder));
        }

        public static Task<IAnswer<IChatMessage[]>> AskMultipleAsync(this IGptChat chat,
            string message, int countOfAnswers,
            Func<IChatMessageParametersBuilder, IChatMessageParameters> parameters)
        {
            var builder = new ChatMessageParametersBuilder();
            return chat.AskMultipleAsync(message, countOfAnswers, parameters.Invoke(builder));
        }
    }
}
