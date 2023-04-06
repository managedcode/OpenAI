namespace ManagedCode.OpenAI.Moderation;

public interface ICategory<out TResult> where TResult : struct
{
    public TResult Hate { get;}
    public TResult HateThreatening { get; }
    public TResult SelfHarm { get; }
    public TResult Sexual { get; }
    public TResult SexualMinors { get; }
    public TResult Violence { get; }
    public TResult ViolenceGraphic { get; }
}