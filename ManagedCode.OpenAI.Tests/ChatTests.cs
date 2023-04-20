using FluentAssertions;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class ChatTests: BaseTestClass
{
    public ChatTests(ITestOutputHelper output, IConfiguration configuration) 
        : base(output, configuration)
    {
    }


    [ManualTest]
    public async Task AskSingle_Success()
    {
        var client = ClientBuilder.Build();

        var chat = client.OpenChat();
        var question1 = "Distance to the sun?";
        var question2 = "Why so far?";

        Log($"Question: '{question1}'");
        var answer1 = await chat.AskAsync(question1);
        Log($"Answer: '{answer1.Data.Content}'");

        Log($"Question: '{question2}'");
        var answer2 = await chat.AskAsync(question2);
        Log($"Answer: '{answer2.Data.Content}'");

        answer1.Data.Content.Should().NotBeNullOrWhiteSpace();
        answer2.Data.Content.Should().NotBeNullOrWhiteSpace();
    }

    [ManualTest]
    public async Task AskMultiple_Success()
    {
        var client = ClientBuilder.Build();
        var chat = client.OpenChat();
        var question = "Distance to the sun?";

        Log($"Question: '{question}'");
        var answer = await chat.AskMultipleAsync(question, 3);

        foreach (var chatMessage in answer.Data)
        {
            Log($"Answer: '{chatMessage.Content}'");
            chatMessage.Content.Should().NotBeNullOrWhiteSpace();
        }
    }


    [ManualTest]
    public async Task ChatSessionSaveLoad_Success()
    {
        var client = ClientBuilder.Build();
        var chat = client.OpenChat();
        var question = "Distance to the sun?";

        await chat.AskAsync(question);
        var sessionJson = chat.Session.ToJson();
        Log($"Session json: '{sessionJson}'");

        var newChat = client.OpenChat(x => x.FromJson(sessionJson));
        var loadedSessionJson = newChat.Session.ToJson();
        Log($"Loaded session json: '{loadedSessionJson}'");

        sessionJson.Should().BeEquivalentTo(loadedSessionJson);
    }
}