using ManagedCode.OpenAI.Chats.Enums;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Chats;

public static class ChatRequestBuilderMethods
{
    public static ChatRequestBuilder AsChat(this OpenAIClient.OpenAIClient client, string modelId)
    {
        return new ChatRequestBuilder(client, modelId);
    }
    
    public static ChatRequestBuilder AsChat(this OpenAIClient.OpenAIClient client, Model model)
    {
        return AsChat(client, model.Id);
    }
    
    public static ChatRequestBuilder AsChat(this OpenAIClient.OpenAIClient client, ChatModel model)
    {
        return AsChat(client, model);
    }
    
    
}