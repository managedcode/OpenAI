using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.ImageGenerator;

public class ImageGeneratorRequest
{
    [JsonProperty("prompt")] public string Prompt;
    
    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)] 
    public int? N;
    
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public string? Size;
    
    [JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
    public string? ResponseFormat;
    
    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
    public string? User;
}