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
    
    
    public async Task<IFileInfo> CreateFileAsync(string content, string fileName, string purpose = "fine-tune")
    {
        var fileInfoDto = await _client.CreateFileAsync(content, fileName, purpose);
        
        return fileInfoDto.ToFileInfo();
    }
    
    public async Task<IFileInfo> CreateFileAsync(Stream content, string fileName, string purpose = "fine-tune")
    {
        var fileInfoDto = await _client.CreateFileAsync(content, fileName, purpose);
        
        return fileInfoDto.ToFileInfo();
    }

    public async Task<IFileInfo> CreateFileAsync(byte[] content, string fileName, string purpose = "fine-tune")
    {
        var fileInfoDto = await _client.CreateFileAsync(content, fileName, purpose);
        
        return fileInfoDto.ToFileInfo();
    }

    public async Task<IFileInfo> CreateFileAsync(ReadOnlyMemory<byte> content, string fileName, string purpose = "fine-tune")
    {
        var fileInfoDto = await _client.CreateFileAsync(content, fileName, purpose);
        
        return fileInfoDto.ToFileInfo();
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