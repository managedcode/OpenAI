using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client
{
    internal class Answer<TModel> : IAnswer<TModel>
    {
        public required TModel Data { get; set; }
        public required IUsage Usage { get; set; }
        public required int Created { get; set; }
        public required string ModelId { get; set; }
        public required string Id { get; set; }
    }
}
