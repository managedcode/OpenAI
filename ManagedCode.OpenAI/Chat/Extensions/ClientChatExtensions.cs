using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public static class ClientChatExtensions
{
    public static IOpenAiChat OpenChat(this IOpenAIClient client)
    {
        return client.OpenChat(new ChatSession());
    }

    public static IOpenAiChat OpenChat(this IOpenAIClient client, IChatSession session)
    {
        ArgumentNullException.ThrowIfNull(session);
        
        var builder = new ChatMessageParametersBuilder();
        builder.SetModel(client.Configuration.ModelId);
        return client.OpenChat(builder.Build(), session);
    }

    public static IOpenAiChat OpenChat(this IOpenAIClient client, IChatMessageParameters defaultMessageParameters)
    {
        return client.OpenChat(defaultMessageParameters, new ChatSession());
    }
}