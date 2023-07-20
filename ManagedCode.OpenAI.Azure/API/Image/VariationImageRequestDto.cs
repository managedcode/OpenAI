using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Image;

internal class VariationImageRequestDto : BaseImageRequestDto
{
    [JsonPropertyName("image")]
    public string ImageBase64 { get; set; }
}