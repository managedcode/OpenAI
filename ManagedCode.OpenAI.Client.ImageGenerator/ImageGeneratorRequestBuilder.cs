using System.Text;
using ManagedCode.Methods;
using ManagedCode.OpenAI.Client.Exceptions;
using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.ImageGenerator;

public class ImageGeneratorRequestBuilder
{
    public const string URL_EDITS = "https://api.openai.com/v1/images/generations";
    
    private OpenAIClient _client;
    private ImageGeneratorRequest _request;

    public ImageGeneratorRequestBuilder(OpenAIClient client)
    {
        _client = client;
    }
    

    public ImageGeneratorRequestBuilder SetPrompt(string prompt)
    {
        _request.Prompt = prompt;

        return this;
    }
    
    public ImageGeneratorRequestBuilder SetRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _request.N = count;

        return this;
    }
    
    public ImageGeneratorRequestBuilder SetResolution(string size)
    {

        _request.Size = size;

        return this;
    }

    public ImageGeneratorRequestBuilder SetResolution(ImageResolution resize)
    {
        return SetResolution(resize.GetDescription());
    }
    
    public ImageGeneratorRequestBuilder SetFormat(string format)
    {

        _request.ResponseFormat = format;

        return this;
    }

    public ImageGeneratorRequestBuilder SetFormat(ImageFormat format)
    {
        return SetFormat(format.GetDescription());
    }

    public ImageGeneratorRequestBuilder SetUser(string user)
    {
        _request.User = user;

        return this;
    }
    
    public async Task<CreateImageResult> Send()
    {
        var json = JsonConvert.SerializeObject(_request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var httpResponseMessage = await _client.PostAsync(
            URL_EDITS, content);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<CreateImageResult>(responseBody);

        return result;
    }

    public ImageGeneratorRequestBuilder Clear(string prompt)
    {
        _request = new ImageGeneratorRequest()
        {
            Prompt = prompt
        };

        return this;
    }
    
    
    public ImageGeneratorRequestBuilder Clear()
    {
        return Clear(_request.Prompt);
    }
}