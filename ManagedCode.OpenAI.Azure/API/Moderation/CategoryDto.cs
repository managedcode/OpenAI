using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Moderation;

internal class CategoryDto<TResult> where TResult : struct
{
    [JsonPropertyName("hate")]
    public TResult Hate { get; set; }

    [JsonPropertyName("hate/threatening")]
    public TResult HateThreatening { get; set; }

    [JsonPropertyName("self-harm")]
    public TResult SelfHarm { get; set; }

    [JsonPropertyName("sexual")]
    public TResult Sexual { get; set; }

    [JsonPropertyName("sexual/minors")]
    public TResult SexualMinors { get; set; }

    [JsonPropertyName("violence")]
    public TResult Violence { get; set; }

    [JsonPropertyName("violence/graphic")]
    public TResult ViolenceGraphic { get; set; }
}