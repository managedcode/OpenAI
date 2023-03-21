using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Models;

public class ListModels
{
    [JsonPropertyName("data")]
    public Model[] Models {get; set; }

    [JsonPropertyName("object")]
    public string Object {get; set; }
    
    
    
}