using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Exceptions;

namespace ManagedCode.OpenAI.ImageGenerator.Manager;

public class ImageManager<T> where T : class
{
    public const string URL_EDITS = "images/generations";
    
    protected OpenAIClient _client;
    protected ImageRequestOptions _options;
    
    public ImageManager(OpenAIClient client, ImageRequestOptions options)
    {
        _client = client;
        _options = options;
    }

    public ImageManager<T> Prompt(string prompt)
    {
        _options.Prompt = prompt;

        return this;
    }
    
    public async Task<T> GetResultAsStringAsync()
    {

        var httpResponseMessage = await _client.PostAsJsonAsync(
            URL_EDITS, _options);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(responseBody);

        return result;
    }
}