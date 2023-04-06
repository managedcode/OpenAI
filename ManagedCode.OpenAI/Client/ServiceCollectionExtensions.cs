using Microsoft.Extensions.DependencyInjection;

namespace ManagedCode.OpenAI.Client;

public static class ServiceCollectionExtensions
{
    public static void AddOpenAI(this IServiceCollection collection, string apiKey)
    {
        collection.AddSingleton<IGptClient>(s => new GptClient(apiKey));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        Action<IGptClientBuilder> build)
    {
        var builder = new GptClientBuilder(apiKey);
        build.Invoke(builder);
        collection.AddSingleton<IGptClient>(s => builder.Build());
    }
}