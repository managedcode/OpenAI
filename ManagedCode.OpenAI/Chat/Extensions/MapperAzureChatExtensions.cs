using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat;

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
            Created = dto.Created.GetHashCode()
        };
    }
    
    public static IChatMessage ToChatMessage(this ChatChoice dto)
    {
        return new ChatMessage
        {
            Content = dto.Message.Content,
            Role = dto.Message.Role.ToString(),
            FinishReason = dto.FinishReason
        };
    }
}