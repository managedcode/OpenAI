using Newtonsoft.Json;
using ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Client.Editor;

public class EditResult
{
    [JsonProperty("object")]
    public string Object;

    [JsonProperty("created")]
    public int Created;

    [JsonProperty("choices")]
    public List<ChoiceEdit> Choices;

    [JsonProperty("usage")]
    public Usage Usage;
}