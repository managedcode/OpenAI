using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Files.Models;

internal class FileInfoDto
{
    [JsonPropertyName("id")]
    public string Id  { get; set; }

    [JsonPropertyName("object")]
    public string Object  { get; set; }

    [JsonPropertyName("bytes")]
    public int Bytes  { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt  { get; set; }

    [JsonPropertyName("filename")]
    public string Filename  { get; set; }

    [JsonPropertyName("purpose")]
    public string Purpose  { get; set; }
}