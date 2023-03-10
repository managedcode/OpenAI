using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Completions;

public class ChoiceComplete
{
    [JsonProperty("text")]
    public string Text;

    [JsonProperty("index")]
    public int Index;

    [JsonProperty("logprobs")]
    public object Logprobs;

    [JsonProperty("finish_reason")]
    public string FinishReason;
}