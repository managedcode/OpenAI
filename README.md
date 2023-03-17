# OpenAI

[![.NET](https://github.com/managedcode/OpenAI/actions/workflows/dotnet.yml/badge.svg)](https://github.com/managedcode/OpenAI/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/managedcode/OpenAI/badge.svg?branch=main&service=github)](https://coveralls.io/github/managedcode/OpenAI?branch=main)
[![nuget](https://github.com/managedcode/OpenAI/actions/workflows/nuget.yml/badge.svg?branch=main)](https://github.com/managedcode/Communication/actions/workflows/nuget.yml)
[![CodeQL](https://github.com/managedcode/OpenAI/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/managedcode/OpenAI/actions/workflows/codeql-analysis.yml)
[![NuGet Package](https://img.shields.io/nuget/v/ManagedCode.OpenAI.svg)](https://www.nuget.org/packages/ManagedCode.OpenAI) 

# Usage

## Sipliest Completions Sample without any additional options
```csharp
var chat = FluentChatGPT.ChatBuilder("apiKey").Build();

chat.NewConversation().AsUser("message");

var responce = await chat.GetCompletionAsync();
```


## Completions Sample with optional configuration
```csharp
var chat = FluentChatGPT.ChatBuilder("apiKey")
    .WithTemperature(0.5)
    .WithTopP(0.1)
    .WithMaxTokens(60)
    .Build();

chat.NewConversation()
    .AsSystem("Act as Historian, operate by dates only")
    .AsUser("give me a year of the end of the First World War:")
    .AsAssistant("1918")
    .AsUser("year of titanic movie production:");

var response = await chat.GetCompletionAsync();
```
