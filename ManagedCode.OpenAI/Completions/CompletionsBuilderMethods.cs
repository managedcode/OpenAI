using ManagedCode.OpenAI.Completions.Enums;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Completions;

public static class CompletionsBuilderMethods
{
    public static CompletionsBuilder AsCompletions(this OpenAIClient.OpenAIClient client, string modelId)
    {
        return new CompletionsBuilder(client, modelId);
    }
    
    public static CompletionsBuilder AsCompletions(this OpenAIClient.OpenAIClient client, Model model)
    {
        return client.AsCompletions(model.Id);
    }
    
    public static CompletionsBuilder AsCompletions(this OpenAIClient.OpenAIClient client, CompletionModel model)
    {
        return client.AsCompletions(model);
    }
}