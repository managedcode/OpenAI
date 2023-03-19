using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Editor;

public class ChoiceEdit
{
    [JsonPropertyName("text")]
    public string Text;

    [JsonPropertyName("index")]
    public int Index;
}