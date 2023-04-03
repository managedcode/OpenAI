using ManagedCode.OpenAI.Moderations.Abstractions;

namespace ManagedCode.OpenAI.Moderations.Model;

public class Moderation: IModeration
{
    public required ICategory<bool> Categories { get; set; }
    public required ICategory<float> CateroryScores { get; set; }
}