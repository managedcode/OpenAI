using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.ImageGenerator.Manager;

public class UrlImageManager : ImageManager<ImageResult<UrlImageData>>
{
    public UrlImageManager(OpenAIClient client, ImageRequestOptions options) : base(client, options)
    {
    }
    
}