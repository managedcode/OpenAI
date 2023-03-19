using System.Net.Http;

namespace ManagedCode.OpenAI.OpenAIClient;

public class OpenAIClient : HttpClient
{
    public const string AUTHORIZATION = "Authorization";
    public const string AUTHORIZATION_FORMAT = "Bearer {0}";

    public const string ORGANIZATION = "OpenAI-Organization";

    public static OpenAIClient Create(string apiKey)
    {
        var client = new OpenAIClient();
        client.DefaultRequestHeaders.Add(
            AUTHORIZATION,
            string.Format(AUTHORIZATION_FORMAT, apiKey)
        );

        return client;
    }
    
    public static OpenAIClient Create(string apiKey, string organization)
    {
        var client = Create(apiKey);

        client.DefaultRequestHeaders.Add(
            ORGANIZATION,
            organization
        );

        return client;
    }
}