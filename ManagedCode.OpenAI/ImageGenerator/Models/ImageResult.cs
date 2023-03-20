using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageResult
{
    [JsonPropertyName("url")]
    public string Url  { get; set; }
    
    [JsonPropertyName("b64_json")]
    public string Base64Json  { get; set; }
}