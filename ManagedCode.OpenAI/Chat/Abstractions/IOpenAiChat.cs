using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public interface IOpenAiChat
{
    public IChatSession Session { get; }

    public Task<IAnswer<IChatMessage>> AskAsync(string message);

    public Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters);

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers);

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers,
        IChatMessageParameters parameters);
    
    public Task<IAnswer<IChatMessage>> AskMultipleAsync(IChatSessionRecord[] records,
        IChatMessageParameters parameters);
}