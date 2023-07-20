namespace ManagedCode.OpenAI.Client;

internal class Model : IModel
{
    public required string Id { get; set; }
    public required string OwnedBy { get; set; }
    public required IPermission[] Permission { get; set; }
}