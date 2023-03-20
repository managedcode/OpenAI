using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class CreateImageResult
{
    [JsonPropertyName("created")]
    public int Created  { get; set; }

    [JsonPropertyName("data")]
    public List<ImageResult> Data  { get; set; }
}