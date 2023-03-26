using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Client
{
    public class DefaultGptClientConfiguration : IGptClientConfiguration
    {
        private const GptModel DEFAULT_MODEL = GptModel.Turbo;

        public DefaultGptClientConfiguration()
        {
            ModelId = DEFAULT_MODEL.Name();
        }

        public string ModelId { get; set; }
    }
}
