using System.Net;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.API.Errors;

public class OpenAIException : HttpRequestException
{
    public OpenAIException(string message, string code, HttpStatusCode statusCode
    ) :
        base(message, null, statusCode)
    {
        ErrorCode = code;
    }

    public OpenAIException(OpenAIErrorCode errorCode)
    {
        ErrorCode = errorCode.Name();
    }

    public string ErrorCode { get; }
}
