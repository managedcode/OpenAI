using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.File;

internal class FilesInfoResponseDto
{
    [JsonPropertyName("data")]
    public FileInfoDto[] Data { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }
}