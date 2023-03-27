using System.Text;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Files.Abstractions;
using ManagedCode.OpenAI.Files.Extensions;


namespace ManagedCode.OpenAI.Files.Builders;

public class FileManager : IFileManager
{
    private readonly IOpenAiWebClient _client;

    internal FileManager(IOpenAiWebClient webClient)
    {
        _client = webClient;
    }

    public async Task<IFileInfo[]> FileListAsync()
    {
        var response = await _client.FilesInfoAsync();
        return response.ToFileInfoArray();
    }

    public async Task<IFileInfo> CreateFileAsync(
        string fileName,
        HttpContent content,
        string purpose = "fine-tune")
    {
        var response = 
            await _client.CreateFileAsync(content, fileName, purpose);
        return response.ToFileInfo();
    }
    
    public async Task<IFileInfo> CreateFileAsync(string fileName, string content, string purpose = "fine-tune")
    {
        var stringContent = new StringContent(content, Encoding.UTF8, "multipart/form-data");
        return await CreateFileAsync(fileName, stringContent, purpose);
    }
    
    public async Task<IFileInfo> CreateFileAsync(string fileName, Stream content, string purpose = "fine-tune")
    {
        var streamContent = new StreamContent(content);
        return await CreateFileAsync(fileName, streamContent, purpose);
    }
    
    

    public async Task<bool> DeleteFileAsync(string fileId)
    {
        var response = await _client.DeleteFileAsync(fileId);
        return response.GetDeleteResult();
    }
    
    public async Task<bool> DeleteFileAsync(IFileInfo file)
    {
        return await DeleteFileAsync(file.Id);
    }
    

    public async Task<IFileInfo> FileInfoAsync(string fileId)
    {
        var response = await _client.FileInfoAsync(fileId);
        return response.ToFileInfo();
    }
    
    

    public async Task<string> FileContentAsync(IFileInfo info)
    {
        return await FileContentAsync(info.Id);
    }

    public async Task<string> FileContentAsync(string fileId)
    {
        return await _client.GetContentFromFileAsync(fileId);
    }
}