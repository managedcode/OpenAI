
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