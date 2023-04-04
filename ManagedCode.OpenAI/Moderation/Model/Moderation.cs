namespace ManagedCode.OpenAI.Moderation;

public class Moderation: IModeration
{
    public required ICategory<bool> Categories { get; set; }
    public required ICategory<float> CategoryScores { get; set; }
}