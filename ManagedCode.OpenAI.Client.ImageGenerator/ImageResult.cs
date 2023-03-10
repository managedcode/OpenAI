using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.ImageGenerator;

public class ImageResult
{
    [JsonProperty("url")]
    public string Url;
    
    [JsonProperty("b64_json")]
    public string Base64Json;
}