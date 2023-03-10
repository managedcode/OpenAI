using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.ImageGenerator;

public class CreateImageResult
{
    [JsonProperty("created")]
    public int Created;

    [JsonProperty("data")]
    public List<ImageResult> Data;
}