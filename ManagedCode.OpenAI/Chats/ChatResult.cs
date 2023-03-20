using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.ManagedCode.OpenAI.Client.Usages;

namespace ManagedCode.OpenAI.Chats;

public class ChatResult
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")] 
    public List<ChoiceChat> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}