using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Editor;

public class ChoiceEdit
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }
}