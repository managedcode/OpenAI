namespace ManagedCode.OpenAI.Files;

public interface IFileInfo
{
    string Id { get; }
    int Bytes { get; }
    DateTime CreatedAt { get; }
    string Filename { get; }
    string Purpose { get; }
}