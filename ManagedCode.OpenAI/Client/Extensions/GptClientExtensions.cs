﻿using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client;

public static class GptClientExtensions
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