using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Tests.Extensions
{
    public static class GenericTypeExtensions
    {
        public static bool Is<T>(this T val1, T val2)
            where T: IEquatable<T>
        {
            return EqualityComparer<T>.Default.Equals(val1, val2);
        }

        public static string ToJson<TModel>(this TModel model)
            where TModel:class
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented);
        }
    }
}
