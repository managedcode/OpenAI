using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.Client;

public enum RoleType
{
    [EnumMember(Value = "user")] User,

    [EnumMember(Value = "assistant")] Assistant,
    
    [EnumMember(Value = "system")] System,
}