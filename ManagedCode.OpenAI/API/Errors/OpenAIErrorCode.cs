using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.API.Errors;

public enum OpenAIErrorCode
{
    [EnumMember(Value = "model_not_found")]
    ModelNotFound,
}
