using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Models;

public class ListModels
{
    [JsonProperty("data")]
    public Model[] Models;

    [JsonProperty("object")]
    public string Object;
    
    
    
}