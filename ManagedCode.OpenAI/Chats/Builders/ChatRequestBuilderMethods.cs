using ManagedCode.OpenAI.Chats.Enums;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Chats;

public static class ChatRequestBuilderMethods
{
    
    public static ChatRequestBuilder CreateChatBuilder(this OpenAIClient client, ChatModel model)
    {
        return new ChatRequestBuilder(client, model);
    }

}