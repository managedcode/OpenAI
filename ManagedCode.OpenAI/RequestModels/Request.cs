using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.RequestModels;
public class Request
{
    public string Model { get; set; } = null!;
    public double Temperature {get; set;}

    [JsonPropertyName("top_p")]
    public double TopP {get; set;}

    [JsonPropertyName("max_tokens")]
    public int MaxTokens {get; set;}

    public List<RequestMessage> Messages { get; set; } = null!;
}
