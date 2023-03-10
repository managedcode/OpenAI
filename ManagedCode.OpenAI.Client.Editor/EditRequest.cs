using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Editor;

public class EditRequest
{
    [JsonProperty("model")]
    public string Model;

    [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)] 
    public string Input;
    
    [JsonProperty("instruction", NullValueHandling = NullValueHandling.Ignore)] 
    public string Instruction;
    
    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)] 
    public int? N;
    
    [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)] 
    public float? Temperature;

    [JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)] 
    public int? TopP;

}