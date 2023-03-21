using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class Base64ImageData
{
    [JsonPropertyName("b64_json")]
    public string Base64Json { get; set; }
}