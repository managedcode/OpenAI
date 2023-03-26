using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client
{
    public interface IAnswer<out TModel>
    {
        public TModel Data { get; }

        public IUsage Usage { get; }

        public int Created { get; }

        public string ModelId { get; }

        public string Id { get; }
    }
}
