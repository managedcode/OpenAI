using System.ComponentModel;

namespace ManagedCode.OpenAI.Completions.Enums;

public enum CompletionModel
{
    [Description("text-curie-001")]
    TextCurie001,

    [Description("text-babbage-001")]
    TextBabbage001,

    [Description("text-ada-001")]
    TextAda001,

    [Description("text-davinci-002")]
    TextDavinci002,

    [Description("text-davinci-001")]
    TextDavinci001,

    [Description("davinci-instruct-beta")]
    DavinciInstructBeta,

    [Description("davinci")]
    Davinci,

    [Description("curie-instruct-beta")]
    CurieInstructBeta,

    [Description("curie")]
    Curie,

    [Description("babbage")]
    Babbage,

    [Description("ada")]
    Ada,

    [Description("code-davinci-002")]
    CodeDavinci002,

    [Description("code-cushman-001")]
    CodeCushman001
}