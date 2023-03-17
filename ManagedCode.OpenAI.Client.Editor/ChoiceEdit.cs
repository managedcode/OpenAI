using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Editor;

public class ChoiceEdit
{
    [JsonProperty("text")]
    public string Text;

    [JsonProperty("index")]
    public int Index;
}