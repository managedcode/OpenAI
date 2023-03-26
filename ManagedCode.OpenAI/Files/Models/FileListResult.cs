using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Files.Models;

public class FileListResult
{
    [JsonPropertyName("data")]
    public List<FileInfo> Data  { get; set; }

    [JsonPropertyName("object")]
    public string Object  { get; set; }
}