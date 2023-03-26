namespace ManagedCode.OpenAI.Image
{
    public interface IGptImage<out TData>
    {
        TData Content { get; }

        int Created { get; }
    }
}
