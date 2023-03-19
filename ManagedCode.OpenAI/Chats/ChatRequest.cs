using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats;

public class ChatRequest
{
    [JsonPropertyName("model")]
    public string Model;
    
    [JsonPropertyName("messages")]
    public List<Message> Messages = new List<Message>();
    
    [JsonPropertyName("temperature")] 
    public float? Temperature;

    [JsonPropertyName("top_p")] 
    public int? TopP;

    [JsonPropertyName("n")] 
    public int? N;

    [JsonPropertyName("stream")] 
    public bool? Stream;
    
    [JsonPropertyName("max_tokens")] 
    public int? MaxTokens;
    
    [JsonPropertyName("presence_penalty")] 
    public float? PresencePenalty;
    
    [JsonPropertyName("frequency_penalty")] 
    public float? FrequencyPenalty;
    
    [JsonPropertyName("logit_biat")] 
    public Dictionary<string, int>? LogitBias;
    
    [JsonPropertyName("user")] 
    public string? User;
}