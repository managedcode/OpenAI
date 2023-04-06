using System.Net;

namespace ManagedCode.OpenAI.Exceptions;

public static class OpenAIExceptions
{
    public static void ThrowsIfError(HttpStatusCode statusCode)
    {
        if (statusCode == HttpStatusCode.Unauthorized) throw new OpenAIInvalidApiKey();
    }
}