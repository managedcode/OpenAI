using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Completions.Enums;
using ManagedCode.OpenAI.Interfaces;

namespace ManagedCode.OpenAI.Completions;

public class CompletionRequestOptions : 
    ICloneable<CompletionRequestOptions>, 
    IDeepCloneable<CompletionRequestOptions>
{

    [JsonPropertyName("model")] 
    public CompletionModel Model { get; set; }

    [JsonPropertyName("prompt")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Prompt { get; set; } = new List<string>();

    
    [JsonPropertyName("suffix")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Suffix { get; set; }

    [JsonPropertyName("max_tokens")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxTokens { get; set; }

    [JsonPropertyName("temperature")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Temperature { get; set; }

    [JsonPropertyName("top_p")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TopP { get; set; }
    
    [JsonPropertyName("n")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? N { get; set; }

    [JsonPropertyName("stream")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stream { get; set; }

    [JsonPropertyName("logprobs")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Logprobs { get; set; }

    [JsonPropertyName("echo")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Echo { get; set; }
    
    [JsonPropertyName("stop")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Stop { get; set; }

    [JsonPropertyName("presence_penalty")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? PresencePenalty { get; set; }
    
    [JsonPropertyName("frequency_penalty")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? FrequencyPenalty { get; set; }
    
    [JsonPropertyName("best_of")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BestOf { get; set; }
    
    [JsonPropertyName("logit_biat")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, int>? LogitBias { get; set; }
    
    [JsonPropertyName("user")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? User { get; set; }

    public CompletionRequestOptions Clone() 
        => (CompletionRequestOptions)MemberwiseClone();

    public CompletionRequestOptions DeepClone()
    {
        var clone = Clone();
        
        clone.Prompt = Prompt?.Count != 0 ? new List<string>(Prompt) : new List<string>();

        return clone;
    }
}