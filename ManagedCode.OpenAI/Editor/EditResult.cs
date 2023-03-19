using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Editor;

public class EditResult
{
    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("created")]
    public int Created;

    [JsonPropertyName("choices")]
    public List<ChoiceEdit> Choices;

    [JsonPropertyName("usage")]
    public Usage Usage;
}