namespace ManagedCode.OpenAI.Moderation;

public interface IModeration
{
    ICategory<bool> Categories { get; }
    ICategory<float> CategoryScores { get; }
}