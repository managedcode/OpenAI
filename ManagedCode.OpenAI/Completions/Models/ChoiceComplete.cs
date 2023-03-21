using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Completions;

public class ChoiceComplete
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("logprobs")]
    public object Logprobs { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}