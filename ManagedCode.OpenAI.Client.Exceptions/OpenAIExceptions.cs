using System.Net;

namespace ManagedCode.OpenAI.Client.Exceptions;

public static class OpenAIExceptions
{
    public static void ThrowsIfError(HttpStatusCode statusCode)
    {

        if (statusCode == HttpStatusCode.Unauthorized)
        {
            throw new OpenAIInvalidApiKey();
        }
        
    }
}