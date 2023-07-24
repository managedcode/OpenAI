using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.JsonAttributes;

public class JsonStringEnumConverter2Lower : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var type = typeof(JsonStringEnumConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter)Activator.CreateInstance(type)!;
    }
}