using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Errors;

internal class OpenAIErrorResponse
{
    [JsonPropertyName("error")]
    public OpenAIError Error { get; set; }

}

internal class OpenAIError
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }
}
