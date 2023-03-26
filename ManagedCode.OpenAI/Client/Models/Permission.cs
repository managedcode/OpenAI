namespace ManagedCode.OpenAI.Client
{
    internal class Permission : IPermission
    {
        public required string Id { get; set; }
        public required int Created { get; set; }
        public required bool AllowCreateEngine { get; set; }
        public required bool AllowSampling { get; set; }
        public required bool AllowLogProbs { get; set; }
        public required bool AllowSearchIndices { get; set; }
        public required bool AllowView { get; set; }
        public required bool AllowFineTuning { get; set; }
        public required string Organization { get; set; }
        public required bool IsBlocking { get; set; }
    }
}
