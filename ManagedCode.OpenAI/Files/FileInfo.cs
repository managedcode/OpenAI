namespace ManagedCode.OpenAI.Files;

public class FileInfo : IFileInfo
{
    public required string Id  { get; set; }
    public required int Bytes  { get; set; }
    public required DateTime CreatedAt  { get; set; }
    public required string Filename  { get; set; }
    public required string Purpose  { get; set; }
}