using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

public static class ClientChatExtensions
{
    public static IOpenAiChat OpenChat(this IOpenAIClient<IGptClientConfiguration, IGptClientConfigurationBuilder> client)
    {
        return client.OpenChat(new ChatSession());
    }

    public static IOpenAiChat OpenChat(this IOpenAIClient<IGptClientConfiguration, IGptClientConfigurationBuilder> client, IChatSession session)
    {
        var builder = new ChatMessageParametersBuilder();
        builder.SetModel(client.Configuration.ModelId);
        return client.OpenChat(builder.Build(), session);
    }

    public static IOpenAiChat OpenChat(this IOpenAIClient<IGptClientConfiguration, IGptClientConfigurationBuilder> client, IChatMessageParameters defaultMessageParameters)
    {
        return client.OpenChat(defaultMessageParameters, new ChatSession());
    }
}