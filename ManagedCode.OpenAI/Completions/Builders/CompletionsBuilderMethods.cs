using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Completions.Enums;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Completions;

public static class CompletionsBuilderMethods
{

    public static CompletionsBuilder CreateCompletionsBuilder(this OpenAIClient client, CompletionModel model)
    {
        return new CompletionsBuilder(client, model);
    }
}