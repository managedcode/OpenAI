using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Completions;

public class CompletionResult
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object {get; set;}

    [JsonPropertyName("created")]
    public int Created {get; set;}

    [JsonPropertyName("model")]
    public string Model {get; set;}

    [JsonPropertyName("choices")]
    public List<ChoiceComplete> Choices {get; set;}

    [JsonPropertyName("usage")]
    public Usage Usage {get; set;}
}