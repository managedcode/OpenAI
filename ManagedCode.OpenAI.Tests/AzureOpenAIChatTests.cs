using Azure;
using Azure.AI.OpenAI;
using FluentAssertions;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class AzureOpenAIChatTests : BaseTestClass
{
    public AzureOpenAIChatTests(ITestOutputHelper output, IConfiguration configuration) 
        : base(output, configuration)
    {
    }
    
    [Fact]
    public async Task AskSingle_Success()
    {
        var options = new ChatCompletionsOptions
        {
            MaxTokens = 400,
            Temperature = 1f,
            FrequencyPenalty = 0.0f,
            PresencePenalty = 0.0f,
            NucleusSamplingFactor = 0.95f // Top P
        };
        
        var client = AzureOpenAiClient.Builder(
            new Uri("https://winkt.openai.azure.com/"),
            new AzureKeyCredential("daa53e8248714e709333f138a12495aa"))
            .Configure(options)
            .Build();
        
        var chat = client.OpenChat();

        await chat.AskAsync("grg");

        var response = await chat.AskAsync("How are you?");
        var response2 = await chat.AskAsync("Tell me what is C#");
        var response3 = await chat.AskAsync("Where we can use them?");
        var response4 = await chat.AskAsync("Help me describe creating modern desktop app with c#");

        response.Should().NotBeNull();
    }
}