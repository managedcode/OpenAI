using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Editor;

public class EditResult
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    public List<ChoiceEdit> Choices { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}