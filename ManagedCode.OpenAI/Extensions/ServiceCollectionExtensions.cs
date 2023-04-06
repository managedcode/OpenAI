using ManagedCode.OpenAI.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCode.OpenAI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddOpenAI(this IServiceCollection collection, string apiKey)
    {
        collection.AddSingleton<IGptClient>(s => new GptClient(apiKey));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey, string organization)
    {
        collection.AddSingleton<IGptClient>(s => new GptClient(apiKey, organization));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        IGptClientConfiguration configuration)
    {
        collection.AddSingleton<IGptClient>(s => new GptClient(apiKey, configuration));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        Action<DefaultGptClientConfiguration> configuration)
    {
        var config = new DefaultGptClientConfiguration();
        configuration.Invoke(config);
        collection.AddSingleton<IGptClient>(s => new GptClient(apiKey, config));
    }
}