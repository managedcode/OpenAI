using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;

namespace ManagedCode.OpenAI.ImageGenerator.Enums;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ImageFormat
{
    [EnumMember(Value = "url")]
    [Description("url")]
    Url,
    
    [EnumMember(Value = "b64_json")]
    [Description("b64_json")]
    Base64Json,
}