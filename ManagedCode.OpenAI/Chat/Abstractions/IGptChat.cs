using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat
{
    public interface IGptChat
    {
        public IChatSession Session { get; }

        public Task<IAnswer<IChatMessage>> AskAsync(string message);

        public Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters);

        public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers);

        public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers,
            IChatMessageParameters parameters);
    }
}
