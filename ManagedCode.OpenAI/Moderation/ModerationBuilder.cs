using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Moderation;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Moderation;

internal class ModerationBuilder : IModerationBuilder
{
    private const GptModel DEFAULT_MODEL = GptModel.TextModerationStable;
    private readonly IOpenAiWebClient _client;
    private readonly ModerationRequestDto _requestDto;

    public ModerationBuilder(IOpenAiWebClient client)
    {
        _client = client;
        _requestDto = new ModerationRequestDto
        {
            Model = DEFAULT_MODEL.Name()
        };
    }

    public IModerationBuilder SetModel(string model)
    {
        _requestDto.Model = model;
        return this;
    }

    public IModerationBuilder SetModel(GptModel model)
    {
        return SetModel(model.Name());
    }

    public async Task<IModeration> ExecuteAsync(string input)
    {
        _requestDto.Input = new List<string> { input };
        var moderationResponseDto = await _client.ModerationAsync(_requestDto);
        return moderationResponseDto.ToModeration();
    }

    public async Task<IModeration[]> ExecuteMultipleAsync(params string[] inputs)
    {
        _requestDto.Input = inputs.ToList();
        var moderationResponseDto = await _client.ModerationAsync(_requestDto);
        return moderationResponseDto.ToModerationCollection();
    }
}