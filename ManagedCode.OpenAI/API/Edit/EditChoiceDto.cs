using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Edit;

public class EditChoiceDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }
}