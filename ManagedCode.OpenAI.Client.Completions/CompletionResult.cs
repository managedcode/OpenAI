using Newtonsoft.Json;
using ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Client.Completions;

public class CompletionResult
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("object")]
    public string Object;

    [JsonProperty("created")]
    public int Created;

    [JsonProperty("model")]
    public string Model;

    [JsonProperty("choices")]
    public List<ChoiceComplete> Choices;

    [JsonProperty("usage")]
    public Usage Usage;
}