using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Files;

public class FileListResult
{
    [JsonProperty("data")]
    public List<FileInfo> Data;

    [JsonProperty("object")]
    public string Object;
}