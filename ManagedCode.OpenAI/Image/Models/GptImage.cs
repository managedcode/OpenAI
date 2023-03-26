namespace ManagedCode.OpenAI.Image
{
    internal class GptImage<TData> : IGptImage<TData>
    {
        public required TData Content { get; set; }
        public required int Created { get; set; }
    }
}
