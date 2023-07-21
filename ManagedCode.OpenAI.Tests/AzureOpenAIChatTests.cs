using Azure;
using Azure.AI.OpenAI;
using FluentAssertions;
using ManagedCode.OpenAI.Azure.Chat;
using ManagedCode.OpenAI.Azure.Client;
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
    
    [ManualTest]
    public async Task AskSingle_Success()
    {
        var client = AzureOpenAiClient.Builder(
            new Uri(""),
            new AzureKeyCredential(""))
            .Configure(c => c.SetDefaultModel("gpt-35-turbo"))
            .Build();

        var conf = new ChatMessageParameters()
        {
            Role = ChatRole.User.ToString(),
            MaxTokens = 800,
            Temperature = 0.95f,
            FrequencyPenalty = 0.0f,
            PresencePenalty = 0.0f,
            NucleusSamplingFactor = 0.95f // Top P
        };
        
        var chat = client.OpenChat(conf);

        await chat.AskAsync("f");

        var response = await chat.AskAsync("How are you?");
        var response2 = await chat.AskAsync("Tell me what is C#");
        var response3 = await chat.AskAsync("Where we can use them?");
        var response4 = await chat.AskAsync("Help me describe creating modern desktop app with c#");

        response.Should().NotBeNull();
    }
}