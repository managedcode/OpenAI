using ManagedCode.OpenAI.Moderations.Abstractions;

namespace ManagedCode.OpenAI.Moderations.Model;

internal class Category<TResult> : ICategory<TResult> where TResult : struct
{
    public required TResult Hate { get; set; }
    public required TResult HateThreatening { get; set; }
    public required TResult SelfHarm { get; set; }
    public required TResult Sexual { get; set; }
    public required TResult SexualMinors { get; set; }
    public required TResult Violence { get; set; }
    public required TResult ViolenceGraphic { get; set; }
}