using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.File;

internal class FileDeleteResponseDto
{
    [JsonPropertyName("id")] 
    public string Id  { get; set; }

    [JsonPropertyName("object")] 
    public string Object  { get; set; }

    [JsonPropertyName("deleted")] 
    public bool Deleted  { get; set; }
}