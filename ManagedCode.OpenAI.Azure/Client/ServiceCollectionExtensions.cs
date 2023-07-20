using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("ManagedCode.OpenAI.Tests", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace ManagedCode.OpenAI.Client;

public static class ServiceCollectionExtensions
{
    public static void AddOpenAI(this IServiceCollection collection, string apiKey)
    {
        //collection.AddSingleton<IOpenAIClient>(s => new GptClient(apiKey));
    }

    public static void AddOpenAI(this IServiceCollection collection, string apiKey,
        Action<IGptClientBuilder> build)
    {
        //var builder = new GptClientBuilder(apiKey);
        //build.Invoke(builder);
       //collection.AddSingleton<IOpenAIClient>(s => builder.Build());
    }
}