using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Moderation;

internal class ModerationResponseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
    
    [JsonPropertyName("results")]
    public CategoryResultDto[] Results { get; set; }
}