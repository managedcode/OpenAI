namespace ManagedCode.OpenAI.Completions
{
    public interface ICompletionsMessage
    {
        public string Content { get; }
        public string FinishReason { get; }
        public int? LogProbs { get; set; }
    }
}
