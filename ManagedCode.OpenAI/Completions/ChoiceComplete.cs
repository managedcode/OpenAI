using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Completions;

public class ChoiceComplete
{
    [JsonPropertyName("text")]
    public string Text;

    [JsonPropertyName("index")]
    public int Index;

    [JsonPropertyName("logprobs")]
    public object Logprobs;

    [JsonPropertyName("finish_reason")]
    public string FinishReason;
}