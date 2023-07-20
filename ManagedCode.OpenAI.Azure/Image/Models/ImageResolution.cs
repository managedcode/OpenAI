using System.ComponentModel;
using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.Image;

public enum ImageResolution
{
    [EnumMember(Value = "256x256")]
    [Description("256x256")]
    _256x256,

    [EnumMember(Value = "512x512")]
    [Description("512x512")]
    _512x512,

    [EnumMember(Value = "1024x1024")]
    [Description("1024x1024")]
    _1024x1024
}