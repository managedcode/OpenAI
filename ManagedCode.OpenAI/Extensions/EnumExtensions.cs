using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.Extensions;

internal static class EnumExtensions
{
    public static string Name(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attributes = (EnumMemberAttribute[])field!.GetCustomAttributes(
            typeof(EnumMemberAttribute), false);

        if (attributes.Length == 0) return value.ToString();

        return attributes.First().Value
               ?? throw new Exception($"{value} value property not specified in attribute");
    }
}