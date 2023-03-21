using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Editor.Enums;

namespace ManagedCode.OpenAI.Editor;

public class EditRequestOptions
{
    [JsonPropertyName("model")]
    public EditModel Model { get; set; }

    [JsonPropertyName("input")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Input { get; set; } 
    
    [JsonPropertyName("instruction")] 
    public string Instruction { get; set; }
    
    [JsonPropertyName("n")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? N { get; set; }
    
    [JsonPropertyName("temperature")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Temperature { get; set; }

    [JsonPropertyName("top_p")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? TopP { get; set; }

}