using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Chats;

public class ChatRequest
{
    [JsonProperty("model")]
    public string Model;
    
    [JsonProperty("messages")]
    public List<Message> Messages = new List<Message>();
    
    [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)] 
    public float? Temperature;

    [JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)] 
    public int? TopP;

    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)] 
    public int? N;

    [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)] 
    public bool? Stream;
    
    [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)] 
    public int? MaxTokens;
    
    [JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)] 
    public float? PresencePenalty;
    
    [JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)] 
    public float? FrequencyPenalty;
    
    [JsonProperty("logit_biat", NullValueHandling = NullValueHandling.Ignore)] 
    public Dictionary<string, int>? LogitBias;
    
    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)] 
    public string? User;
}