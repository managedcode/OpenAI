using System.ComponentModel;
using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.Image;

public enum ImageFormat
{
    [EnumMember(Value = "url")]
    [Description("url")]
    Url,

    [EnumMember(Value = "b64_json")]
    [Description("b64_json")]
    Base64Json,
}