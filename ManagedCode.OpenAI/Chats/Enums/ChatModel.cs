using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats.Enums;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ChatModel
{
    [EnumMember(Value = "gpt-3.5-turbo")]
    [Description("gpt-3.5-turbo")]
    Turbo,
    
    [EnumMember(Value = "gpt-3.5-turbo-0301")]
    [Description("gpt-3.5-turbo-0301")]
    Turbo0301
}