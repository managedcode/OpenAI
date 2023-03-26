using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Chat.Extensions;

namespace ManagedCode.OpenAI.Client.Extensions
{
    public static class GptClientEx
    {
        public static IGptChat OpenChat(this IGptClient client,
            IChatMessageParameters defaultMessageParameters, string json)
        {
            return client.OpenChat(defaultMessageParameters, x => x.FromJson(json));
        }

        public static IGptChat OpenChat(this IGptClient client, Func<IChatSessionLoader, IChatSession> session)
        {
            var sessionLoader = DefaultSessionLoader();
            return client.OpenChat(session.Invoke(sessionLoader));
        }

        public static IGptChat OpenChat(this IGptClient client, IChatMessageParameters defaultMessageParameters,
            Func<IChatSessionLoader, IChatSession> session)
        {
            var sessionLoader = DefaultSessionLoader();
            return client.OpenChat(defaultMessageParameters, session.Invoke(sessionLoader));
        }

        private static IChatSessionLoader DefaultSessionLoader()
        {
            return new ChatSessionLoader();
        }
    }
}
