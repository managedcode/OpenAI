using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Moderation;

public interface IModerationBuilder
{
    public IModerationBuilder SetModel(string model);
    public IModerationBuilder SetModel(GptModel model);
    
    public IModerationBuilder AddInput(string input);
    public IModerationBuilder AddInput(IEnumerable<string> inputs);
    
    public Task<IModeration> ExecuteAsync();
    public Task<IModeration[]> ExecuteMultipleAsync();
    
    
}