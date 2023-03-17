
using ManagedCode.Methods;
using ManagedCode.OpenAI.Client.Models;

namespace ManagedCode.OpenAI.Client.Chats;

public static class ChatRequestBuilderMethods
{
    public static ChatRequestBuilder AsChat(this OpenAIClient client, string modelId)
    {
        return new ChatRequestBuilder(client, modelId);
    }
    
    public static ChatRequestBuilder AsChat(this OpenAIClient client, Model model)
    {
        return AsChat(client, model.Id);
    }
    
    public static ChatRequestBuilder AsChat(this OpenAIClient client, ChatModel model)
    {
        return AsChat(client, model.GetDescription());
    }
    
    
}