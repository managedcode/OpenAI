using ManagedCode.OpenAI.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCode.OpenAI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddOpenAI(this IServiceCollection collection, string apiKey)
    {
        collection.AddSingleton<IOpenAIClient>(s => new GptClient(apiKey));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey, string organization)
    {
        collection.AddSingleton<IOpenAIClient>(s => new GptClient(apiKey, organization));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        IOpenAiClientConfiguration configuration)
    {
        collection.AddSingleton<IOpenAIClient>(s => new GptClient(apiKey, configuration));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        Action<DefaultOpenAiClientConfiguration> configuration)
    {
        var config = new DefaultOpenAiClientConfiguration();
        configuration.Invoke(config);
        collection.AddSingleton<IOpenAIClient>(s => new GptClient(apiKey, config));
    }
}