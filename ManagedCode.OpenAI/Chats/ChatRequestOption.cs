using System.Collections.Generic;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;
using ManagedCode.OpenAI.Interfaces;

namespace ManagedCode.OpenAI.Chats;


public class ChatRequestOption: ICloneable<ChatRequestOption>, IDeepCloneable<ChatRequestOption>
{
    [JsonPropertyName("model")]
    public ChatModel Model { get; set; }
    
    [JsonPropertyName("messages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Message> Messages { get; set; } = new List<Message>();
    
    [JsonPropertyName("temperature")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Temperature { get; set; }

    [JsonPropertyName("top_p")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? TopP { get; set; }

    [JsonPropertyName("n")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? N { get; set; }

    [JsonPropertyName("stream")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stream { get; set; }
    
    [JsonPropertyName("max_tokens")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxTokens { get; set; }
    
    [JsonPropertyName("presence_penalty")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? PresencePenalty { get; set; }
    
    [JsonPropertyName("frequency_penalty")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? FrequencyPenalty { get; set; }
    
    [JsonPropertyName("logit_biat")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, int>? LogitBias { get; set; }
    
    [JsonPropertyName("user")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? User { get; set; }


    public ChatRequestOption DeepClone()
    {
        var result = Clone();

        result.Messages = Messages?.Count != 0 ? new List<Message>(Messages) : new List<Message>();
        
        result.LogitBias = LogitBias;
        
        return result;

    }

    public ChatRequestOption Clone() => (ChatRequestOption)MemberwiseClone();
}