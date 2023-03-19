using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleType
{
    user,
    assistant
}