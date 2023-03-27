namespace ManagedCode.OpenAI.Files.Abstractions;

public interface IFileInfo
{
    string Id { get; }
    int Bytes { get; }
    DateTime CreatedAt { get; }
    string Filename { get; }
    string Purpose { get; }
}