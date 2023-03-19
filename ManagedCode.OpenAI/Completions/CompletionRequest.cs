using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Completions;

public class CompletionRequest
{

    [JsonPropertyName("model")] 
    public string Model;

    [JsonPropertyName("prompt")] 
    public string[]? Prompt;
    
    [JsonPropertyName("suffix")] 
    public string? Suffix;

    [JsonPropertyName("max_tokens")] 
    public int? MaxTokens;

    [JsonPropertyName("temperature")] 
    public float? Temperature;

    [JsonPropertyName("top_p")] 
    public int? TopP;

    [JsonPropertyName("n")] 
    public int? N;

    [JsonPropertyName("stream")] 
    public bool? Stream;

    [JsonPropertyName("logprobs")] 
    public int? Logprobs;

    [JsonPropertyName("echo")] 
    public bool? Echo;
    
    [JsonPropertyName("stop")] 
    public string[]? Stop;

    [JsonPropertyName("presence_penalty")] 
    public float? PresencePenalty;
    
    [JsonPropertyName("frequency_penalty")] 
    public float? FrequencyPenalty;
    
    [JsonPropertyName("best_of")] 
    public int? BestOf;
    
    [JsonPropertyName("logit_biat")] 
    public Dictionary<string, int>? LogitBias;
    
    [JsonPropertyName("user")] 
    public string? User;
}