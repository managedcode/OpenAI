using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Files;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client
{

    public interface IGptClient
    {
        public IGptClientConfiguration Configuration { get; }

        public IImageClient ImageClient { get; }
        public IFileClient FileClient { get; }

        void Configure(IGptClientConfiguration configuration);
        void Configure(Func<IGptClientConfigurationBuilder, IGptClientConfiguration> configuration);

        public Task<IModel[]> GetModelsAsync();
        public Task<IModel> GetModelAsync(string modelId);

        IGptChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session);
        ICompletionBuilder Completion();
        IEditBuilder Edit(string input, string instruction);
        IModerationBuilder Moderation();
    }
}
