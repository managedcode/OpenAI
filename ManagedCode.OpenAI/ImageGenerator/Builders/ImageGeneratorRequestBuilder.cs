using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.ImageGenerator.Enums;
using ManagedCode.OpenAI.ImageGenerator.Manager;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageGeneratorRequestBuilder
{
    public const string URL_EDITS = "images/generations";

    private OpenAIClient _client;
    private ImageRequestOptions _request;

    public ImageGeneratorRequestBuilder(OpenAIClient client)
    {
        _client = client;
    }

    public ImageGeneratorRequestBuilder WithRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _request.N = count;

        return this;
    }


    public ImageGeneratorRequestBuilder WithResolution(ImageResolution resize)
    {
        _request.Size = resize;

        return this;
    }



    public ImageGeneratorRequestBuilder WithUsername(string user)
    {
        _request.User = user;

        return this;
    }

    public Base64ImageManager CreateAsBase64()
    {
        var options = _request.DeepClone();
        options.ResponseFormat = ImageFormat.Base64Json;
        
        return new Base64ImageManager(_client, options);
    }
    
    public UrlImageManager CreateAsUrl()
    {
        var options = _request.DeepClone();
        options.ResponseFormat = ImageFormat.Url;

        return new UrlImageManager(_client, options);
    }

    public ImageGeneratorRequestBuilder Clear()
    {
        _request = new ImageRequestOptions();
        
        return this;
    }
}