using System.ComponentModel;

namespace ManagedCode.OpenAI.ImageGenerator.Enums;

public enum ImageFormat
{
    [Description("url")]
    Url,
    
    [Description("b64_json")]
    Base64Json,
}