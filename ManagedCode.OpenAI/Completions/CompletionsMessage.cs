namespace ManagedCode.OpenAI.Completions
{
    internal class CompletionsMessage : ICompletionsMessage
    {
        public required string Content { get; set; }
        public required string FinishReason { get; set; }
        public required int? LogProbs { get; set; }
    }
}
