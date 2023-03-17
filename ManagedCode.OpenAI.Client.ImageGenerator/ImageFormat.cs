using System.ComponentModel;

namespace ManagedCode.OpenAI.Client.ImageGenerator;

public enum ImageFormat
{
    [Description("url")]
    Url,
    
    [Description("b64_json")]
    Base64Json,
}