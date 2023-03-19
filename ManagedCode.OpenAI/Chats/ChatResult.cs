using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Chats;

public class ChatResult
{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("created")]
    public int Created;

    [JsonPropertyName("choices")] 
    public List<ChoiceChat> Choices = new();

    [JsonPropertyName("usage")]
    public Usage Usage;
}