using System.ComponentModel.DataAnnotations;

namespace ManagedCode.OpenAI.Chat;

public class ChatMessageParameters : IChatMessageParameters
{
    public string? Role { get; set; }
    public string? ModelId { get; set; }

    [Range(0, 2f)]
    public float? Temperature { get; set; }

    public float? TopP { get; set; }
    public bool? Stream { get; set; }

    [Range(0, 2048)]
    public int? MaxTokens { get; set; }

    [Range(-2f, 2f)]
    public float? PresencePenalty { get; set; }

    [Range(-2f, 2f)]
    public float? FrequencyPenalty { get; set; }
    
    [Range(0, 1f)]
    public float? NucleusSamplingFactor { get; set; }

    public Dictionary<string, int>? LogitBias { get; set; }
    public string? User { get; set; }
}