using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Files;

public class FileListResult
{
    [JsonPropertyName("data")]
    public List<FileInfo> Data  { get; set; }

    [JsonPropertyName("object")]
    public string Object  { get; set; }
}