using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Models;

public class Model
{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("owned_by")]
    public string OwnedBy;

    [JsonPropertyName("permission")]
    public Permission[] Permission;
}