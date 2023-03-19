using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Models;

public class ListModels
{
    [JsonPropertyName("data")]
    public Model[] Models;

    [JsonPropertyName("object")]
    public string Object;
    
    
    
}