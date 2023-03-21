using System.Net.Http;

namespace ManagedCode.OpenAI.Client;

public class OpenAIClient : HttpClient
{
    public const string AUTHORIZATION = "Authorization";
    public const string AUTHORIZATION_FORMAT = "Bearer {0}";

    public const string ORGANIZATION = "OpenAI-Organization";

    public const string BASE_URL = "https://api.openai.com/v1/";

    private static readonly Lazy<Uri> s_LazyBaseUri = new Lazy<Uri>(() => new Uri(BASE_URL));
    private static Uri s_baseUri => s_LazyBaseUri.Value;

    public static OpenAIClient Create(string apiKey)
    {
        var client = new OpenAIClient();
        client.DefaultRequestHeaders.Add(
            AUTHORIZATION,
            string.Format(AUTHORIZATION_FORMAT, apiKey)
        );

        client.BaseAddress = s_baseUri;

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