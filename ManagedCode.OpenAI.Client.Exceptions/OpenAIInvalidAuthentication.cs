using System.Net;

namespace ManagedCode.OpenAI.Client.Exceptions;

public class OpenAIInvalidAuthentication : OpenAIClientException
{
    public OpenAIInvalidAuthentication() : base(
        "Invalid Authentication. Ensure the correct API key and requesting organization are being used.",
        null,
        HttpStatusCode.Unauthorized)
    {
    }
}