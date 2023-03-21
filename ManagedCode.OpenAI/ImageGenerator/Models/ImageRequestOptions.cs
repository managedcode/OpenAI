using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ImageGenerator.Enums;
using ManagedCode.OpenAI.Interfaces;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageRequestOptions : ICloneable<ImageRequestOptions>, IDeepCloneable<ImageRequestOptions>
{
    [JsonPropertyName("prompt")] 
    public string Prompt { get; set; }
    
    [JsonPropertyName("n")] 
    public int? N  { get; set; }
    
    [JsonPropertyName("size")]
    public ImageResolution? Size  { get; set; }
    
    [JsonPropertyName("response_format")]
    public ImageFormat? ResponseFormat  { get; set; }
    
    [JsonPropertyName("user")]
    public string? User  { get; set; }

    public ImageRequestOptions Clone() => (ImageRequestOptions) MemberwiseClone();

    public ImageRequestOptions DeepClone() => Clone();
}