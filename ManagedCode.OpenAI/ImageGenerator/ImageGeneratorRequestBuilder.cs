using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.ImageGenerator.Enums;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageGeneratorRequestBuilder
{
    public const string URL_EDITS = "https://api.openai.com/v1/images/generations";
    
    private OpenAIClient.OpenAIClient _client;
    private ImageGeneratorRequest _request;

    public ImageGeneratorRequestBuilder(OpenAIClient.OpenAIClient client)
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
        return SetResolution(resize);
    }
    
    public ImageGeneratorRequestBuilder SetFormat(string format)
    {

        _request.ResponseFormat = format;

        return this;
    }

    public ImageGeneratorRequestBuilder SetFormat(ImageFormat format)
    {
        return SetFormat(format);
    }

    public ImageGeneratorRequestBuilder SetUser(string user)
    {
        _request.User = user;

        return this;
    }
    
    public async Task<CreateImageResult> Send()
    {
        var json = JsonSerializer.Serialize(_request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var httpResponseMessage = await _client.PostAsync(
            URL_EDITS, content);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<CreateImageResult>(responseBody);

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