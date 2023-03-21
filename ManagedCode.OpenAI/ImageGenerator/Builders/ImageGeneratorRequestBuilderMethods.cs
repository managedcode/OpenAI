using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.ImageGenerator;

public static class ImageGeneratorRequestBuilderMethods
{
    public static ImageGeneratorRequestBuilder CreateImageBuilder(this OpenAIClient client) 
        => new ImageGeneratorRequestBuilder(client);
}