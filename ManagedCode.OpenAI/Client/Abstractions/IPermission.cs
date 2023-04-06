namespace ManagedCode.OpenAI.Client;

public interface IPermission
{
    public string Id { get; }

    public int Created { get; }

    public bool AllowCreateEngine { get; }

    public bool AllowSampling { get; }

    public bool AllowLogProbs { get; }

    public bool AllowSearchIndices { get; }

    public bool AllowView { get; }

    public bool AllowFineTuning { get; }

    public string Organization { get; }

    public bool IsBlocking { get; }
}