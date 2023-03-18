namespace ManagedCode.OpenAI.Client.Files;

public static class FileManagerMethods
{
    
    public static FileManager AsFileManager(this OpenAIClient client)
    {
        return new FileManager(client);
    }
}