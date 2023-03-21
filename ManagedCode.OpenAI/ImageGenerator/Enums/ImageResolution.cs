using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;

namespace ManagedCode.OpenAI.ImageGenerator.Enums;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ImageResolution
{
    [EnumMember(Value = "256x256")]
    [Description("256x256")]
    Small,
    
    [EnumMember(Value = "512x512")]
    [Description("512x512")]
    Medium,
    
    [EnumMember(Value = "1024x1024")]
    [Description("1024x1024")]
    Large
}