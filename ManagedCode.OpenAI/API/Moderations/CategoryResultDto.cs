using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Moderations;

public class CategoryResultDto
{
    [JsonPropertyName("categories")]
    public CategoryDto<bool> Categories { get; set; }
    
    [JsonPropertyName("category_scores")]
    public CategoryDto<float> CategoryScores { get; set; }
    
    [JsonPropertyName("flagged")]
    public bool Flagged { get; set; }
}