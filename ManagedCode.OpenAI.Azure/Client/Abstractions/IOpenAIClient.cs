using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Completions;
using ManagedCode.OpenAI.Edit;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Moderation;

namespace ManagedCode.OpenAI.Client;

public interface IOpenAIClient<TConf, TConfBuilder> 
{
    public TConf Configuration { get; }

    public IImageClient ImageClient { get; }

    void Configure(TConf configuration);
    void Configure(Func<TConfBuilder, TConf> configuration);

    public Task<IModel[]> GetModelsAsync();
    public Task<IModel> GetModelAsync(string modelId);

    IOpenAiChat OpenChat(IChatMessageParameters defaultMessageParameters, IChatSession session);
    ICompletionBuilder Completion(string prompt);
    IEditBuilder Edit(string input, string instruction);
    IModerationBuilder Moderation();
}