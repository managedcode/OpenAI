using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Moderation;

public interface IModerationBuilder
{
    public IModerationBuilder SetModel(string model);
    public IModerationBuilder SetModel(GptModel model);
   
    public Task<IModeration> ExecuteAsync(string input);
    public Task<IModeration[]> ExecuteMultipleAsync(params string[] inputs);
}