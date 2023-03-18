using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Files;

public class FileDeleteResult
{
    [JsonProperty("id")] public string Id;

    [JsonProperty("object")] public string Object;

    [JsonProperty("deleted")] public bool Deleted;
}