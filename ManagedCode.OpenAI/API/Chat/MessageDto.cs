using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.API;

internal class MessageDto
{
    [JsonPropertyName("role")]
    public RoleType Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}