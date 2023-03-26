using System.Net;

namespace ManagedCode.OpenAI.Exceptions;

public abstract class OpenAIClientException : HttpRequestException
{
    public OpenAIClientException(
        string message,
        Exception? exception,
        HttpStatusCode statusCode
    ) :
        base(message, exception, statusCode)
    {
        this.HelpLink = "https://platform.openai.com/docs/guides/error-codes/api-errors";
    }
}