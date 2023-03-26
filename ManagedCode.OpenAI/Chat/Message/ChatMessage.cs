namespace ManagedCode.OpenAI.Chat
{
    internal class ChatMessage : IChatMessage
    {
        public required string Content { get; set; }
        public required string Role { get; set; }

        public required string FinishReason { get; set; }
    }
}
