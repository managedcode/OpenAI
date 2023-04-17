//using ManagedCode.OpenAI.Client;
//using ManagedCode.OpenAI.Files;
//using ManagedCode.OpenAI.Tests.Base;
//using Xunit;
//using Xunit.Abstractions;

//namespace ManagedCode.OpenAI.Tests;

//public class FileTest
//{
//    private const string SKIP = $"Class {nameof(FileTest)} disabled";


//    private const string fileContent =
//        @"{""prompt"":""This is a test"", ""completion"":""This is a test""}";

//    private readonly IGptClient _client = Mocks.Client();
//    private readonly IFileClient _fileClient;


//    private readonly ITestOutputHelper _output;


//    public FileTest(ITestOutputHelper output)
//    {
//        _output = output;
//        _fileClient = _client.FileClient;
//    }

//    [Fact(Skip = SKIP)]
//    public async Task UploadFile_Success()
//    {
//        const string fileName = "test.txt";


//        var file = await _fileClient.CreateFileAsync(fileContent, fileName);

//        Log($"File id: {file.Id}");

//        Assert.False(string.IsNullOrWhiteSpace(file.Id));
//        Assert.Equal(fileName, file.Filename);
//        Assert.Equal(fileContent.Length, file.Bytes);
//    }


//    // Needs premium account
//    [Fact(Skip = SKIP)]
//    public async Task ContentFile_Success()
//    {
//        var fileId = await _fileClient.FileListAsync()
//            .ContinueWith(t => t.Result[0].Id);

//        var content = await _fileClient.FileContentAsync(fileId);

//        Log($"File content: {content}");

//        Assert.Equal(fileContent, content);
//    }

//    [Fact(Skip = SKIP)]
//    public async Task FileList_Success()
//    {
//        const string fileName = "test.txt";

//        var newFile = await _fileClient.CreateFileAsync(fileContent, fileName);
//        Assert.NotNull(newFile);

//        var files = await _fileClient.FileListAsync();
//        Assert.NotEmpty(files);


//        foreach (var file in files) Log($"File: {file.Id} - {file.Filename}");

//        var lastFiles = files.First(e => e.Id == newFile.Id);

//        Assert.Equal(newFile.Id, lastFiles.Id);
//        Assert.Equal(newFile.Filename, lastFiles.Filename);
//        Assert.Equal(newFile.Bytes, lastFiles.Bytes);
//    }

//    [Fact(Skip = SKIP)]
//    public async Task DeleteFile_Success()
//    {
//        const string fileName = "test.txt";

//        var newFile = await _fileClient.CreateFileAsync(fileContent, fileName);
//        Assert.NotNull(newFile);

//        //Waiting for file to be deleted
//        Thread.Sleep(5000);

//        var deleted = await _fileClient.DeleteFileAsync(newFile);
//        Log(deleted.ToString());
//        Assert.True(deleted);

//        var files = await _fileClient.FileListAsync();
//        Assert.NotEqual(newFile.Id, files.Last().Id);
//    }

//    [Fact(Skip = SKIP)]
//    public async Task FileInfo_Success()
//    {
//        const string fileName = "test.txt";

//        var newFile = await _fileClient.CreateFileAsync(fileContent, fileName);
//        Assert.NotNull(newFile);

//        var fileInfo = await _fileClient.FileInfoAsync(newFile.Id);
//        Assert.NotNull(fileInfo);

//        Assert.Equal(newFile.Id, fileInfo.Id);
//        Assert.Equal(newFile.Filename, fileInfo.Filename);
//        Assert.Equal(newFile.Bytes, fileInfo.Bytes);
//    }


//    private void Log(string log)
//    {
//        _output.WriteLine(log);
//    }
//}