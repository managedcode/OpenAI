# OpenAI

This is an unofficial C# library for the OpenAI API. As there are no official libraries available, we have created our
own to help C# developers interact with the API easily.

[![.NET](https://github.com/managedcode/OpenAI/actions/workflows/dotnet.yml/badge.svg)](https://github.com/managedcode/OpenAI/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/managedcode/OpenAI/badge.svg?branch=main&service=github)](https://coveralls.io/github/managedcode/OpenAI?branch=main)
[![nuget](https://github.com/managedcode/OpenAI/actions/workflows/nuget.yml/badge.svg?branch=main)](https://github.com/managedcode/Communication/actions/workflows/nuget.yml)
[![CodeQL](https://github.com/managedcode/OpenAI/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/managedcode/OpenAI/actions/workflows/codeql-analysis.yml)
[![NuGet Package](https://img.shields.io/nuget/v/ManagedCode.OpenAI.svg)](https://www.nuget.org/packages/ManagedCode.OpenAI)

## Installation

To install the ManagedCode.OpenAI library from NuGet, you can use the following methods:

### Package Manager

Open the Package Manager Console in Visual Studio and run the following command:

```
Install-Package ManagedCode.OpenAI
```

### .NET CLI

You can also use the .NET CLI to install the package. Open a terminal/command prompt and run the following command:

```
dotnet add package ManagedCode.OpenAI
```

## Usage

Initializing the client
You can initialize the client in two ways:

``` cs
var client1 = GptClient.Builder("#API_KEY#")
    .WithOrganization("#ORGANIZATION#")
    .Build();
```

```cs
var client2 = GptClient.Builder("#API_KEY#")
    .WithOrganization("#ORGANIZATION#")
    .Configure(x => x.SetDefaultModel(GptModel.Ada))
    .Build();
```
or using DI

```cs
builder.Services.AddOpenAI("#API_KEY#");
```

## Generating an image URL

```cs
var client = new GptClient("#API_KEY#");
var img = await client.ImageClient
    .GenerateImage("Big man")
    .AsUrl().ExecuteAsync();

var url = img.Content;
Console.WriteLine(url);
```

### Generating an image URL with editing
```cs
var client = new GptClient("#API_KEY#");
var imgBytes = new byte[] { };
var maskBase64 = "#CONTENT#";

var img = await client.ImageClient
    .EditImage("Change color to red", x => x.FromBytes(imgBytes))
    .SetImageMask(x => x.FromBase64(maskBase64))
    .AsUrl().ExecuteAsync();

// Edited img URL
Console.WriteLine(img.Content);
```

### Editing an image using a mask
```cs
var client = new GptClient("#API_KEY#");
var imgBytes = new byte[] { };
var imgCollection = await client.ImageClient
    .VariationImage(x => x.FromBytes(imgBytes))
    .AsBase64String()
    .ExecuteMultipleAsync(5);

foreach (var imageBase64 in imgCollection.Content)
    Console.WriteLine(imageBase64);
```    

## Generating multiple image variations as base64 strings

Create multiple variations of an image in base64 string format with 5 results:

```cs
var client = new GptClient("#API_KEY#");
var imgBytes = new byte[] { };
var imgCollection = await client.ImageClient
    .VariationImage(x => x.FromBytes(imgBytes))
    .AsBase64String()
    .ExecuteMultipleAsync(5);

foreach (var imageBase64 in imgCollection.Content)
    Console.WriteLine(imageBase64);
```

## Contributing

We welcome contributions to this project. Please submit a pull request or create an issue if you'd like to help improve
this library.

