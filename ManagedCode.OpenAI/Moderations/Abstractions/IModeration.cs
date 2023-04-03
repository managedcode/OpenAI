namespace ManagedCode.OpenAI.Moderations.Abstractions;

public interface IModeration
{
    ICategory<bool> Categories { get; }
    ICategory<float> CateroryScores { get; }
}