namespace ManagedCode.OpenAI.Chat
{
    internal class Usage : IUsage
    {
        public required int PromptTokens { get; set; }
        public required int CompletionTokens { get; set; }
        public required int TotalTokens { get; set; }
    }
}
