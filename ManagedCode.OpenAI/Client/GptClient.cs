using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Files;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client
{
    public class GptClient : IGptClient
    {
        private readonly IOpenAiWebClient _webClient;

        public GptClient(string apiKey)
        {
            _webClient = new OpenAiWebClient(apiKey);
            Configuration = new DefaultGptClientConfiguration();
        }

        public GptClient(string apiKey, IGptClientConfiguration configuration)
        {
            _webClient = new OpenAiWebClient(apiKey);
            Configuration = configuration;
        }

        public IGptClientConfiguration Configuration { get; private set; }

        public void Configure(IGptClientConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(Func<IGptClientConfigurationBuilder, IGptClientConfiguration> configuration)
        {
            var builder = new GptClientConfigurationBuilder();
            Configure(configuration.Invoke(builder));
        }

        public async Task<IModel[]> GetModelsAsync()
        {
            var models = await _webClient.ModelsAsync();
            return models.Models.Select(x => x.ToModel()).ToArray();
        }

        public async Task<IModel> GetModelAsync(string modelId)
        {
            var model = await _webClient.ModelAsync(modelId);
            return model.ToModel();
        }


        public IGptChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session)
        {
            return new GptChat(_webClient, session, defaultMessageParameters);
        }

        public ICompletionBuilder Completion()
        {
            return new CompletionsBuilder(_webClient, Configuration.ModelId);
        }

        public IEditBuilder Edit(string input, string instruction)
        {
            return new EditBuilder(_webClient, Configuration.ModelId, input, instruction);
        }

        public IGenerateImageBuilder GenerateImage(string description)
        {
            return new GenerateImageBuilder(_webClient, description);
        }

        public IEditImageBuilder EditImage(string description, string imageBase64)
        {
            return new EditImageBuilder(_webClient, description, imageBase64);
        }

        public IVariationImageBuilder VariationImage(string imageBase64)
        {
            return new VariationImageBuilder(_webClient, imageBase64);
        }

        public IFileClient FileManager()
        {
            return new FileClient(_webClient);
        }

        public IModerationBuilder ModerationBuilder()
        {
            return new ModerationBuilder(_webClient);
        }
    }
}
