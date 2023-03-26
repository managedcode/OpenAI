
namespace ManagedCode.OpenAI.Chat
{
    public interface IChatMessageParameters
    {
        public string? Role { get; }

        public string? ModelId { get; }

        public float? Temperature { get; }

        public float? TopP { get; }

        public bool? Stream { get; }

        public int? MaxTokens { get; }

        public float? PresencePenalty { get; }

        public float? FrequencyPenalty { get; }

        public Dictionary<string, int>? LogitBias { get; }

        public string? User { get; }
    }
}
