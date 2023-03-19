

using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

public class Usage
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens;

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens;

    [JsonPropertyName("total_tokens")]
    public int TotalTokens;
}