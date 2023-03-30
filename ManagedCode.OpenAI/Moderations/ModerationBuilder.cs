using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Moderations;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;
using ManagedCode.OpenAI.Moderations.Abstractions;
using ManagedCode.OpenAI.Moderations.Exceptions;

namespace ManagedCode.OpenAI.Moderations;

internal class ModerationBuilder: IModerationBuilder
{
    private readonly IOpenAiWebClient _client;
    private readonly ModerationRequestDto _requestDto;
    
    public ModerationBuilder(IOpenAiWebClient client)
    {
        _client = client;
        _requestDto = new ModerationRequestDto();
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
    
    public IModerationBuilder AddInput(string input)
    {
        _requestDto.Input.Add(input);
        return this;
    }
    
    public IModerationBuilder AddInput(IEnumerable<string> inputs)
    {
        _requestDto.Input.AddRange(inputs);
        return this;
    }
    
    public async Task<IModeration> ExecuteAsync()
    {
        ModerationResponseDto moderationResponseDto = await _client.ModerationAsync(_requestDto);

        return moderationResponseDto.ToModeration();
    }
    
    public async Task<IModeration[]> ExecuteMultipleAsync()
    {
        ModerationResponseDto moderationResponseDto = await _client.ModerationAsync(_requestDto);

        return moderationResponseDto.ToModerations();
    }
}