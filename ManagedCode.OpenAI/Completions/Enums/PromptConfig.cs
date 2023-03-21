namespace ManagedCode.OpenAI.Completions.Enums;

[Flags]
public enum PromptConfig
{
    None = 0,
    Reset = (1 << 0),
    Update = (1 << 1),
    Append = (1 << 2),
    AppendAndUpdate = Update | Append,
}