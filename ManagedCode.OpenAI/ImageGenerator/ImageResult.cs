using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageResult
{
    [JsonPropertyName("url")]
    public string Url;
    
    [JsonPropertyName("b64_json")]
    public string Base64Json;
}