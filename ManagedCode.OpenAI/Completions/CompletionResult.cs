using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Completions;

public class CompletionResult
{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("created")]
    public int Created;

    [JsonPropertyName("model")]
    public string Model;

    [JsonPropertyName("choices")]
    public List<ChoiceComplete> Choices;

    [JsonPropertyName("usage")]
    public Usage Usage;
}