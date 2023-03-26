namespace ManagedCode.OpenAI.Files.Builders;

public static class FileManagerMethods
{
    
    public static FileManager CreateFileManager(this HttpClient webClient)
    {
        return new FileManager(webClient);
    }
}