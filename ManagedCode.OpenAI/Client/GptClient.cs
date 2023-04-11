using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client.Abstractions;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Files;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ManagedCode.OpenAI.Tests")]

namespace ManagedCode.OpenAI.Client
{
    public class GptClient : IGptClient
    {
        private IOpenAiWebClient _webClient = null!;

        public static IGptClientBuilder Builder(string apiKey)
        {
            return new GptClientBuilder(apiKey);
        }

        public GptClient(string apiKey)
        {
            Init(apiKey, default, new DefaultGptClientConfiguration());
        }

        public GptClient(string apiKey, IGptClientConfiguration configuration)
        {
            Init(apiKey, default, configuration);
        }

        public GptClient(string apiKey, string organization)
        {
            Init(apiKey, organization, new DefaultGptClientConfiguration());
        }

        public GptClient(string apiKey, string organization, IGptClientConfiguration configuration)
        {
            Init(apiKey, organization, configuration);
        }


        internal GptClient(string apiKey, IGptClientConfiguration configuration, string? organization)
        {
            Init(apiKey, organization, configuration);
        }

        internal GptClient(IOpenAiWebClient webClient)
        {
            _webClient = webClient;
            Configuration = new DefaultGptClientConfiguration();
            ImageClient = new ImageClient(_webClient);
            FileClient = new FileClient(_webClient);

        }

        private GptClient(){}

        private void  Init(string apiKey, string? organization, IGptClientConfiguration configuration)
        {
            var webClient = string.IsNullOrWhiteSpace(organization) 
                ? new OpenAiWebClient(apiKey) 
                : new OpenAiWebClient(apiKey, organization);

            _webClient = webClient;
            Configuration = configuration;
            ImageClient = new ImageClient(_webClient);
            FileClient = new FileClient(_webClient);
        }


        public IGptClientConfiguration Configuration { get; private set; } = null!;
        public IImageClient ImageClient { get; private set; } = null!;
        public IFileClient FileClient { get; private set; } = null!;

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
            return models.Models.Select(selector: x => x.ToModel()).ToArray();
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

        public IModerationBuilder Moderation()
        {
            return new ModerationBuilder(_webClient);
        }
    }
}
