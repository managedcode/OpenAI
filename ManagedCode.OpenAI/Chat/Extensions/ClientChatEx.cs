using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat
{
    public static class ClientChatEx
    {
        public static IGptChat OpenChat(this IGptClient client)
        {
            return client.OpenChat(new ChatSession());
        }

        public static IGptChat OpenChat(this IGptClient client, IChatSession session)
        {
            var builder = new ChatMessageParametersBuilder();
            builder.SetModel(client.Configuration.ModelId);
            return client.OpenChat(builder.Build(), session);
        }

        public static IGptChat OpenChat(this IGptClient client, IChatMessageParameters defaultMessageParameters)
        {
            return client.OpenChat(defaultMessageParameters, new ChatSession());
        }
    }
}
