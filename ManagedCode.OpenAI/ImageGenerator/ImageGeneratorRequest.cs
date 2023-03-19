using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageGeneratorRequest
{
    [JsonPropertyName("prompt")] 
    public string Prompt;
    
    [JsonPropertyName("n")] 
    public int? N;
    
    [JsonPropertyName("size")]
    public string? Size;
    
    [JsonPropertyName("response_format")]
    public string? ResponseFormat;
    
    [JsonPropertyName("user")]
    public string? User;
}