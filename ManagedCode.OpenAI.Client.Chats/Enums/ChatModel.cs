using System.ComponentModel;

namespace ManagedCode.OpenAI.Client.Chats;

public enum ChatModel
{
    [Description("gpt-3.5-turbo")]
    Turbo,
    
    [Description("gpt-3.5-turbo-0301")]
    Turbo0301
}