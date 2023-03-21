using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ImageGenerator.Enums;
using ManagedCode.OpenAI.Interfaces;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageRequestOptions : ICloneable<ImageRequestOptions>, IDeepCloneable<ImageRequestOptions>
{
    [JsonPropertyName("prompt")] 
    public string Prompt { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("n")] 
    public int? N  { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public ImageResolution? Size  { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("response_format")]
    public ImageFormat? ResponseFormat  { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user")]
    public string? User  { get; set; }

    public ImageRequestOptions Clone() => (ImageRequestOptions) MemberwiseClone();

    public ImageRequestOptions DeepClone() => Clone();
}