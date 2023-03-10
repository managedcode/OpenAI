using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Models;

public class Model
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("object")]
    public string Object;

    [JsonProperty("owned_by")]
    public string OwnedBy;

    [JsonProperty("permission")]
    public Permission[] Permission;
}