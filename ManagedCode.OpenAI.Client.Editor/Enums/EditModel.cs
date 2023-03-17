using System.ComponentModel;

namespace ManagedCode.OpenAI.Client.Editor;

public enum EditModel
{
    [Description("text-davinci-edit-001")]
    Text,
    
    [Description("code-davinci-edit-001")]
    Code,
}