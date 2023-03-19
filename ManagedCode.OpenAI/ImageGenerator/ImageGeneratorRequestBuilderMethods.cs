namespace ManagedCode.OpenAI.ImageGenerator;

public static class ImageGeneratorRequestBuilderMethods
{
    public static ImageGeneratorRequestBuilder AsImageGenerator(
        this OpenAIClient.OpenAIClient client,
        string prompt
    )
    {
        return new ImageGeneratorRequestBuilder(client).Clear(prompt);
    }
}