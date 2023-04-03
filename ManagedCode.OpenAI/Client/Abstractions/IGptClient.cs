using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Files.Abstractions;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderations.Abstractions;

namespace ManagedCode.OpenAI.Client
{

    public interface IGptClient
    {
        public IGptClientConfiguration Configuration { get; }
        void Configure(IGptClientConfiguration configuration);
        void Configure(Func<IGptClientConfigurationBuilder, IGptClientConfiguration> configuration);

        public Task<IModel[]> GetModelsAsync();
        public Task<IModel> GetModelAsync(string modelId);

        IGptChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session);

        ICompletionBuilder Completion();
        IEditBuilder Edit(string input, string instruction);

        IGenerateImageBuilder GenerateImage(string description);

        IEditImageBuilder EditImage(string description, string imageBase64);

        IVariationImageBuilder VariationImage(string imageBase64);

        IFileManager FileManager();
        
        IModerationBuilder ModerationBuilder();

    }
}
