namespace ManagedCode.OpenAI.Files;

public interface IFileClient
{
    Task<IFileInfo[]> FileListAsync();
    Task<IFileInfo> CreateFileAsync(string content, string fileName, string purpose = "fine-tune");
    Task<IFileInfo> CreateFileAsync(Stream content, string fileName, string purpose = "fine-tune");
    Task<IFileInfo> CreateFileAsync(byte[] content, string fileName, string purpose = "fine-tune");
    Task<IFileInfo> CreateFileAsync(ReadOnlyMemory<byte> content, string fileName, string purpose = "fine-tune");
    Task<bool> DeleteFileAsync(string fileId);
    Task<bool> DeleteFileAsync(IFileInfo file);
    Task<IFileInfo> FileInfoAsync(string fileId);
    Task<string> FileContentAsync(IFileInfo info);
    Task<string> FileContentAsync(string fileId);
}