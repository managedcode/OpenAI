using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Edit;

internal static class MapperEditExtensions
{
    public static IAnswer<IEditMessage> ToEditAnswer(this EditResponseDto dto)
    {
        return new Answer<IEditMessage>
        {
            Id = dto.Id,
            ModelId = dto.Model,
            Usage = dto.Usage.ToUsage(),
            Data = dto.Choices.First().ToEditMessage(),
            Created = dto.Created
        };
    }

    public static IAnswer<IEditMessage[]> ToEditAnswerCollection(this EditResponseDto dto)
    {
        return new Answer<IEditMessage[]>
        {
            Id = dto.Id,
            ModelId = dto.Model,
            Usage = dto.Usage.ToUsage(),
            Data = dto.Choices.Select(x => x.ToEditMessage()).ToArray(),
            Created = dto.Created
        };
    }

    public static IEditMessage ToEditMessage(this EditChoiceDto dto)
    {
        return new EditMessage
        {
            Content = dto.Text
        };
    }
}