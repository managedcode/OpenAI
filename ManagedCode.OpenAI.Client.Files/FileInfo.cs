using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Files;

public class FileInfo
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("object")]
    public string Object;

    [JsonProperty("bytes")]
    public int Bytes;

    [JsonProperty("created_at")]
    public int CreatedAt;

    [JsonProperty("filename")]
    public string Filename;

    [JsonProperty("purpose")]
    public string Purpose;
}