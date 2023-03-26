namespace ManagedCode.OpenAI.Client
{
    public interface IModel
    {
        public string Id { get; }

        public string OwnedBy { get; }

        public IPermission[] Permission { get; }
    }
}
