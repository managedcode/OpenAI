using Newtonsoft.Json;
using ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Client.Chats;

public class Chat
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("object")]
    public string Object;

    [JsonProperty("created")]
    public int Created;

    [JsonProperty("choices")]
    public List<ChoiceChat> Choices;

    [JsonProperty("usage")]
    public Usage Usage;
}