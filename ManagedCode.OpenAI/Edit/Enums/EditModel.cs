using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;

namespace ManagedCode.OpenAI.Editor.Enums;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum EditModel
{
    [EnumMember(Value = "text-davinci-edit-001")]
    [Description("text-davinci-edit-001")]
    Text,
    
    [EnumMember(Value = "code-davinci-edit-001")]
    [Description("code-davinci-edit-001")]
    Code,
}