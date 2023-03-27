using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Files.Abstractions;

namespace ManagedCode.OpenAI.Files.Models;

public class FilesInfoResponseDto: IDataArrayResponseDto<FileInfoDto>
{
    [JsonPropertyName("data")]
    public FileInfoDto[] Data { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }
}