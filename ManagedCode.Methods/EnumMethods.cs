using System.ComponentModel;
using System.Reflection;

namespace ManagedCode.Methods;

public static class EnumMethods
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        Type type = typeof(T);

        MemberInfo[] memInfo = type.GetMember(value.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
        }
        return value.ToString();
    }
}