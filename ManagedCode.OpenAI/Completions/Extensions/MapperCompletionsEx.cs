using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Completions
{
    internal static class MapperCompletionsEx
    {
        public static ICompletionsMessage ToCompletionsMessage(this CompletionChoiceDto dto)
        {
            return new CompletionsMessage()
            {
                Content = dto.Text,
                LogProbs = dto.Logprobs,
                FinishReason = dto.FinishReason,
            };
        }

        public static IAnswer<ICompletionsMessage> ToCompletionsAnswer(this CompletionResponseDto dto)
        {
            return new Answer<ICompletionsMessage>()
            {
                Id = dto.Id,
                ModelId = dto.Model,
                Usage = dto.Usage.ToUsage(),
                Data = dto.Choices.First().ToCompletionsMessage(),
                Created = dto.Created,
            };
        }

        public static IAnswer<ICompletionsMessage[]> ToCompletionsAnswerCollection(this CompletionResponseDto dto)
        {
            return new Answer<ICompletionsMessage[]>()
            {
                Id = dto.Id,
                ModelId = dto.Model,
                Usage = dto.Usage.ToUsage(),
                Data = dto.Choices.Select(x => x.ToCompletionsMessage()).ToArray(),
                Created = dto.Created,
            };
        }

    }
}
