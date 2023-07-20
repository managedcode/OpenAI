using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Image;

internal class ImageResponseDto
{
    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("data")]
    public List<ImageResponseDataDto> Data { get; set; }
}