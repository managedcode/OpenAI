using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat.Extensions
{
    internal static class MapperChatEx
    {
        public static IPermission ToPermission(this PermissionDto dto)
        {
            return new Permission()
            {
                AllowCreateEngine = dto.AllowCreateEngine,
                AllowFineTuning = dto.AllowFineTuning,
                AllowLogProbs = dto.AllowLogprobs,
                AllowSampling = dto.AllowSampling,
                AllowSearchIndices = dto.AllowSearchIndices,
                AllowView = dto.AllowView,
                Created = dto.Created,
                Id = dto.Id,
                IsBlocking = dto.IsBlocking,
                Organization = dto.Organization,
            };
        }

        public static IAnswer<IChatMessage> ToChatAnswer(this ChatResponseDto dto)
        {
            return new Answer<IChatMessage>()
            {
                Id = dto.Id,
                ModelId = dto.Model,
                Usage = dto.Usage.ToUsage(),
                Data = dto.Choices.First().ToChatMessage(),
                Created = dto.Created,
            };
        }

        public static IAnswer<IChatMessage[]> ToChatAnswerCollection(this ChatResponseDto dto)
        {
            return new Answer<IChatMessage[]>()
            {
                Id = dto.Id,
                ModelId = dto.Model,
                Usage = dto.Usage.ToUsage(),
                Data = dto.Choices.Select(x => x.ToChatMessage()).ToArray(),
                Created = dto.Created,
            };
        }

        public static IChatMessage ToChatMessage(this ChatChoiceDto dto)
        {
            return new ChatMessage()
            {
                Content = dto.Message.Content,
                Role = dto.Message.Role,
                FinishReason = dto.FinishReason,
            };
        }

        public static IUsage ToUsage(this UsageDto dto)
        {
            return new Usage()
            {
                CompletionTokens = dto.CompletionTokens,
                PromptTokens = dto.PromptTokens,
                TotalTokens = dto.TotalTokens,
            };
        }

    }
}
