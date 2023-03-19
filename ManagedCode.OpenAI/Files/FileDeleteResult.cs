using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Files;

public class FileDeleteResult
{
    [JsonPropertyName("id")] 
    public string Id;

    [JsonPropertyName("object")] 
    public string Object;

    [JsonPropertyName("deleted")] 
    public bool Deleted;
}