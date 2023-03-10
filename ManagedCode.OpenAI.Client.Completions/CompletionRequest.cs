using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Completions;

public class CompletionRequest
{

    [JsonProperty("model")] 
    public string Model;

    [JsonProperty("prompt")] 
    public string[]? Prompt;
    
    [JsonProperty("suffix", NullValueHandling = NullValueHandling.Ignore)] 
    public string? Suffix;

    [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)] 
    public int? MaxTokens;

    [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)] 
    public float? Temperature;

    [JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)] 
    public int? TopP;

    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)] 
    public int? N;

    [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)] 
    public bool? Stream;

    [JsonProperty("logprobs", NullValueHandling = NullValueHandling.Ignore)] 
    public int? Logprobs;

    [JsonProperty("echo", NullValueHandling = NullValueHandling.Ignore)] 
    public bool? Echo;
    
    [JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)] 
    public string[]? Stop;

    [JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)] 
    public float? PresencePenalty;
    
    [JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)] 
    public float? FrequencyPenalty;
    
    [JsonProperty("best_of", NullValueHandling = NullValueHandling.Ignore)] 
    public int? BestOf;
    
    [JsonProperty("logit_biat", NullValueHandling = NullValueHandling.Ignore)] 
    public Dictionary<string, int>? LogitBias;
    
    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)] 
    public string? User;
}