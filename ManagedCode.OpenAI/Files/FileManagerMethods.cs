namespace ManagedCode.OpenAI.Files;

public static class FileManagerMethods
{
    
    public static FileManager AsFileManager(this OpenAIClient.OpenAIClient client)
    {
        return new FileManager(client);
    }
}