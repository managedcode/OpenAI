using System.Text;
using ManagedCode.Methods;
using ManagedCode.OpenAI.Client.Exceptions;
using Newtonsoft.Json;
using ManagedCode.OpenAI.Client.Models;

namespace ManagedCode.OpenAI.Client.Editor;

public class EditRequestBuilder
{
    public const string URL_EDITS = "https://api.openai.com/v1/edits";
    
    private OpenAIClient _client;
    private EditRequest _request = new EditRequest();

    public EditRequestBuilder(OpenAIClient client)
    {
        _client = client;
    }
    

    public EditRequestBuilder SetInput(string input)
    {
        _request.Input = input;

        return this;
    }
    
    public EditRequestBuilder SetRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _request.N = count;

        return this;
    }
    
    public EditRequestBuilder SetTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _request.Temperature = temperature;

        return this;
    }

    public EditRequestBuilder SetTopP(int topP)
    {
        _request.TopP = topP;

        return this;
    }
    
    public async Task<EditResult> Send()
    {
        var json = JsonConvert.SerializeObject(_request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var httpResponseMessage = await _client.PostAsync(
            URL_EDITS, content);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<EditResult>(responseBody);

        return result;
    }

    public EditRequestBuilder Clear(string modelId, string instruction)
    {
        _request = new EditRequest()
        {
            Model = modelId,
            Instruction = instruction
        };

        return this;
    }

    public EditRequestBuilder Clear(Model model, string instruction)
    {
        return Clear(model.Id, instruction);
    }

    public EditRequestBuilder Clear(EditModel model, string instruction)
    {
        return Clear(model.GetDescription(), instruction);
    }
    
    public EditRequestBuilder Clear()
    {
        return Clear(_request.Model, _request.Instruction);
    }

}