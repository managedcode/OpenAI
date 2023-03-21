using System.Net.Http.Json;
using System.Text.Json;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Editor.Enums;
using ManagedCode.OpenAI.Exceptions;

namespace ManagedCode.OpenAI.Editor;

public class EditRequestManager
{
    public const string URL_EDITS = "edits";
    
    private readonly OpenAIClient _client;
    private readonly EditRequestOptions _options;

    public EditRequestManager(OpenAIClient client, EditRequestOptions options)
    {
        _client = client;
        _options = options;
    }


    public EditRequestManager Input(string input)
    {
        _options.Input = input;

        return this;
    }
    
    public async Task<EditResult> GetResultAsync()
    {

        var httpResponseMessage = await _client.PostAsJsonAsync(
            URL_EDITS, 
            _options);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        // TODO: Check model 
        var result = JsonSerializer.Deserialize<EditResult>(responseBody);

        return result;
    }
}