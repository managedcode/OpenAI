namespace ManagedCode.OpenAI.Edit;

internal class EditMessage : IEditMessage
{
    public required string Content { get; set; }
}