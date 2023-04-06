using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Image;

internal class BaseImageRequestDto
{
    [Range(0, 10)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("n")]
    public int? N { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("response_format")]
    public string? ResponseFormat { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user")]
    public string? User { get; set; }
}