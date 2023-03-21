using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class UrlImageData
{
    [JsonPropertyName("url")]
    public string Url  { get; set; }
}