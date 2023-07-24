using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ChatMessage = ManagedCode.OpenAI.Chat.ChatMessage;

namespace ManagedCode.OpenAI.Azure.Chat;

internal static class MapperAzureChatExtensions
{
    public static IAnswer<IChatMessage> ToChatAnswer(this ChatCompletions dto)
    {
        return new Answer<IChatMessage>
        {
            Id = dto.Id,
            ModelId = dto.Id,
            Usage = new Usage()
            {
                CompletionTokens = dto.Usage.CompletionTokens,
                PromptTokens = dto.Usage.PromptTokens,
                TotalTokens = dto.Usage.TotalTokens
            },
            Data = dto.Choices.First().ToChatMessage(),
            Created = dto.Created.GetHashCode() //TODO: DATETIME!!!!
        };
    }

    public static IChatMessage ToChatMessage(this ChatChoice dto)
    {
        return new ChatMessage
        {
            Content = dto.Message.Content,
            Role = dto.Message.Role.GetRole(),
            FinishReason = dto.FinishReason.ToString()
        };
    }
}

internal static class AzureOpenAIChatExtensions
{
    public static RoleType GetRole(this ChatRole role)
    {
        if(role == ChatRole.System)
            return RoleType.System;
        if(role == ChatRole.Assistant)
            return RoleType.Assistant;
        if(role == ChatRole.User)
            return RoleType.User;
        
        throw new ArgumentOutOfRangeException(nameof(role), role, null);
        
    }
    
    public static ChatRole GetRole(this RoleType role)
    {
        if(role == RoleType.System)
            return ChatRole.System;
        if(role == RoleType.Assistant)
            return ChatRole.Assistant;
        if(role == RoleType.User)
            return ChatRole.User;
        
        throw new ArgumentOutOfRangeException(nameof(role), role, null);
        
    }
}