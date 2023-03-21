using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ImageGenerator;

public class ImageResult<T>
{
    [JsonPropertyName("created")]
    public int Created  { get; set; }

    [JsonPropertyName("data")]
    public List<T> Data  { get; set; }
}