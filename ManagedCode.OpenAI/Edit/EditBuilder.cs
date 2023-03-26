using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Edit.Extensions;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Edit;

internal class EditRequestBuilder : IEditBuilder
{
    private readonly EditRequestDto _request;
    private readonly IOpenAiWebClient _client;

    public EditRequestBuilder(IOpenAiWebClient client, string model, string input, string instruction)
    {
        _client = client;
        _request = new EditRequestDto()
        {
            Model = model,
            Instruction = instruction,
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


    public async Task<IAnswer<IEditMessage>> EditAsync()
    {
        _request.Validate();
        var response = await _client.EditAsync(_request);
        return response.ToEditAnswer();

    }

    public async Task<IAnswer<IEditMessage[]>> EditMultipleAsync(int count)
    {
        _request.Validate();
        var response = await _client.EditAsync(_request);
        return response.ToEditAnswerCollection();
    }

}