using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Chats.Enums;

public class JsonStringEnumMemberConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy namingPolicy;
    private readonly bool allowIntegerValues;
    private readonly JsonStringEnumConverter jsonStringEnumConverter;

    public JsonStringEnumMemberConverter() : this(null, true) { }

    public JsonStringEnumMemberConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
    {
        this.namingPolicy = namingPolicy;
        this.allowIntegerValues = allowIntegerValues;
        jsonStringEnumConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = typeToConvert
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field =>
                new Tuple<string, string>(
                    field.Name,
                    field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? null
                )
            )
            .Where(tuple => tuple.Item2 != null);
        
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count > 0)
        {
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options);
        }
        else
        {
            return jsonStringEnumConverter.CreateConverter(typeToConvert, options);
        }
    }

    public override bool CanConvert(Type typeToConvert) => this.jsonStringEnumConverter.CanConvert(typeToConvert);
}