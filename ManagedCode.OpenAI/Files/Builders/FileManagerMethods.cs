using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Files;

public static class FileManagerMethods
{
    
    public static FileManager CreateFileManager(this OpenAIClient client)
    {
        return new FileManager(client);
    }
}