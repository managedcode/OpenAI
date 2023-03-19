using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChatModel
{
    [Description("gpt-3.5-turbo")]
    Turbo,
    
    [Description("gpt-3.5-turbo-0301")]
    Turbo0301
}