using System.ComponentModel;
using System.Runtime.Serialization;

namespace ManagedCode.OpenAI.Client;

public enum GptModel
{

    [EnumMember(Value = "gpt-4")]
    [Description("gpt-4")]
    Gpt4,

    [EnumMember(Value = "gpt-4-0613")]
    [Description("gpt-4-0613")]
    Gpt40613,

    [EnumMember(Value = "gpt-4-32k")]
    [Description("gpt-4-32k")]
    Gpt432k,

    [EnumMember(Value = "gpt-4-32k-0613")]
    [Description("gpt-4-32k-0613")]
    Gpt432k0613,

    [EnumMember(Value = "gpt-3.5-turbo")]
    [Description("gpt-3.5-turbo")]
    Gpt35Turbo,

    [EnumMember(Value = "gpt-3.5-turbo-16k")]
    [Description("gpt-3.5-turbo-16k")]
    Gpt35Turbo16k,

    [EnumMember(Value = "gpt-3.5-turbo-0613")]
    [Description("gpt-3.5-turbo-0613")]
    Gpt35Turbo0613,

    [EnumMember(Value = "gpt-3.5-turbo-16k-0613")]
    [Description("gpt-3.5-turbo-16k-0613")]
    Gpt35Turbo16k0613,

    [EnumMember(Value = "text-davinci-003")]
    [Description("text-davinci-003")]
    TextDavinci003,

    [EnumMember(Value = "text-curie-001")]
    [Description("text-curie-001")]
    TextCurie001,

    [EnumMember(Value = "text-babbage-001")]
    [Description("text-babbage-001")]
    TextBabbage001,

    [EnumMember(Value = "text-ada-001")]
    [Description("text-ada-001")]
    TextAda001,

    [EnumMember(Value = "text-davinci-002")]
    [Description("text-davinci-002")]
    TextDavinci002,

    [EnumMember(Value = "text-davinci-001")]
    [Description("text-davinci-001")]
    TextDavinci001,

    [EnumMember(Value = "davinci-instruct-beta")]
    [Description("davinci-instruct-beta")]
    DavinciInstructBeta,

    [EnumMember(Value = "davinci")]
    [Description("davinci")]
    Davinci,

    [EnumMember(Value = "curie-instruct-beta")]
    [Description("curie-instruct-beta")]
    CurieInstructBeta,

    [EnumMember(Value = "curie")]
    [Description("curie")]
    Curie,

    [EnumMember(Value = "babbage")]
    [Description("babbage")]
    Babbage,

    [EnumMember(Value = "ada")]
    [Description("ada")]
    Ada,

    [EnumMember(Value = "code-davinci-002")]
    [Description("code-davinci-002")]
    CodeDavinci002,

    [EnumMember(Value = "code-cushman-001")]
    [Description("code-cushman-001")]
    CodeCushman001,


    [EnumMember(Value = "text-moderation-stable")]
    [Description("text-moderation-stable")]
    TextModerationStable,

    [EnumMember(Value = "text-moderation-latest")]
    [Description("text-moderation-latest")]
    TextModerationLatest,

    [EnumMember(Value = "text-davinci-edit-001")]
    [Description("text-davinci-edit-001")]
    TextDavinciEdit001,
}