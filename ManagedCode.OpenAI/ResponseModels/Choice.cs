using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ResponseModels;

public class Choice
{
    public ResponseMessage Message { get; set; } = null!;

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; } = null!;
    public int Index { get; set; }
}


