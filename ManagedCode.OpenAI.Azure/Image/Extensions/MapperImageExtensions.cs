using ManagedCode.OpenAI.API.Image;

namespace ManagedCode.OpenAI.Image;

internal static class MapperImageExtensions
{
    public static IGptImage<string> AsSingle(this ImageResponseDto response)
    {
        return new GptImage<string>
        {
            Content = ExtractContents(response).First(),
            Created = response.Created
        };
    }

    public static IGptImage<string[]> AsMultiple(this ImageResponseDto response)
    {
        return new GptImage<string[]>
        {
            Content = ExtractContents(response),
            Created = response.Created
        };
    }

    private static string[] ExtractContents(ImageResponseDto response)
    {
        if (!string.IsNullOrWhiteSpace(response.Data.First().Url))
            return response.Data.Select(x => x.Url).ToArray();

        if (!string.IsNullOrWhiteSpace(response.Data.First().B64Json))
            return response.Data.Select(x => x.B64Json).ToArray();

        throw new ArgumentNullException("Failed to get image content");
    }
}