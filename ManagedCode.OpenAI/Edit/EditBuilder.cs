using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Edit;

internal class EditBuilder : IEditBuilder
{
    private const GptModel DEFAULT_MODEL = GptModel.TextDavinciEdit001;
    private readonly IOpenAiWebClient _client;
    private readonly EditRequestDto _request;

    public EditBuilder(IOpenAiWebClient client,string input, string instruction)
    {
        _client = client;
        _request = new EditRequestDto
        {
            Model = DEFAULT_MODEL.Name(),
            Input = input,
            Instruction = instruction
        };
    }

    public IEditBuilder SetModel(string modelId)
    {
        _request.Model = modelId;
        return this;
    }

    public IEditBuilder SetModel(GptModel model)
    {
        _request.Model = model.Name();
        return this;
    }

    public IEditBuilder SetTemperature(float temperature)
    {
        _request.Temperature = temperature;
        return this;
    }

    public IEditBuilder SetTopP(float topP)
    {
        _request.TopP = topP;
        return this;
    }


    public async Task<IAnswer<IEditMessage>> ExecuteAsync()
    {
        _request.Validate();
        var response = await _client.EditAsync(_request);
        return response.ToEditAnswer();
    }

    public async Task<IAnswer<IEditMessage[]>> ExecuteMultipleAsync(int count)
    {
        _request.Validate();
        var response = await _client.EditAsync(_request);
        return response.ToEditAnswerCollection();
    }
}