using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Edit;

internal class EditChoiceDto 
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }
}