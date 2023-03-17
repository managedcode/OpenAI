using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ResponseModels;

public class ChatCompletion
{
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string ObjectType { get; set; } = null!;
    public int Created { get; set; }
    public string Model { get; set; } = null!;
    public Usage Usage { get; set; } = null!;
    public Choice[] Choices { get; set; } = null!;
}


