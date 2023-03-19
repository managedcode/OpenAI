using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Files;

public class FileInfo
{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("bytes")]
    public int Bytes;

    [JsonPropertyName("created_at")]
    public int CreatedAt;

    [JsonPropertyName("filename")]
    public string Filename;

    [JsonPropertyName("purpose")]
    public string Purpose;
}