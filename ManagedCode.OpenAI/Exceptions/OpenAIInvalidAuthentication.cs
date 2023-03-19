using System.Net;

namespace ManagedCode.OpenAI.Exceptions;

public class OpenAIInvalidAuthentication : OpenAIClientException
{
    public OpenAIInvalidAuthentication() : base(
        "Invalid Authentication. Ensure the correct API key and requesting organization are being used.",
        null,
        HttpStatusCode.Unauthorized)
    {
    }
}