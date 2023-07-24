using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.JsonAttributes;

namespace ManagedCode.OpenAI.Client;

[JsonConverter(typeof(JsonStringEnumConverter2Lower))]
public enum RoleType
{
    [EnumMember(Value = "user")] 
    User,

    [EnumMember(Value = "assistant")] 
    Assistant,
    
    [EnumMember(Value = "system")] 
    System,
}