using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.ImageGenerator.Manager;

public class Base64ImageManager: ImageManager<ImageResult<Base64ImageData>>
{
    public Base64ImageManager(OpenAIClient client, ImageRequestOptions options) : base(client, options)
    {
    }
}