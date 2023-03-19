using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Editor;

public class EditRequest
{
    [JsonPropertyName("model")]
    public string Model;

    [JsonPropertyName("input")] 
    public string Input;
    
    [JsonPropertyName("instruction")] 
    public string Instruction;
    
    [JsonPropertyName("n")] 
    public int? N;
    
    [JsonPropertyName("temperature")] 
    public float? Temperature;

    [JsonPropertyName("top_p")] 
    public int? TopP;

}