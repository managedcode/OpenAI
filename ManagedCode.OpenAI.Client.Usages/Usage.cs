using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Usages;

public class Usage
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens;

    [JsonProperty("completion_tokens")]
    public int CompletionTokens;

    [JsonProperty("total_tokens")]
    public int TotalTokens;
}