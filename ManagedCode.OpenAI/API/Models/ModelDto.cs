using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API;

internal class ModelDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; }

    [JsonPropertyName("permission")]
    public PermissionDto[] Permission { get; set; }
}