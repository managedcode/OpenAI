namespace ManagedCode.OpenAI.Files.Abstractions;

public interface IFileManager
{
    Task<IFileInfo[]> FileListAsync();
    Task<IFileInfo> CreateFileAsync(string fileName, HttpContent content, string purpose = "fine-tune");
    Task<IFileInfo> CreateFileAsync(string fileName, string content, string purpose = "fine-tune");
    Task<IFileInfo> CreateFileAsync(string fileName, Stream content, string purpose = "fine-tune");
    Task<bool> DeleteFileAsync(string fileId);
    Task<bool> DeleteFileAsync(IFileInfo file);
    Task<IFileInfo> FileInfoAsync(string fileId);
    Task<string> FileContentAsync(IFileInfo info);
    Task<string> FileContentAsync(string fileId);
}