using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageRequest
{
    [JsonPropertyName("prompt")] 
    public string Prompt  { get; set; }
    
    [JsonPropertyName("n")] 
    public int? N  { get; set; }
    
    [JsonPropertyName("size")]
    public string? Size  { get; set; }
    
    [JsonPropertyName("response_format")]
    public string? ResponseFormat  { get; set; }
    
    [JsonPropertyName("user")]
    public string? User  { get; set; }
}