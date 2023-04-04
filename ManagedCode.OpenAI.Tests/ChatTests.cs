using System.ComponentModel.DataAnnotations;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using Xunit;
using Xunit.Abstractions;
using static System.String;

namespace ManagedCode.OpenAI.Tests;

public class ChatTests
{
    private readonly ITestOutputHelper _output;
    private readonly IGptClient _client = Mocks.Client();

    public ChatTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task AskSingle_Success()
    {
        var chat = _client.OpenChat();
        var question1 = "Distance to the sun?";
        var question2 = "Why so far?";

        Log($"Question: '{question1}'");
        var answer1 = await chat.AskAsync(question1);
        Log($"Answer: '{answer1.Data.Content}'");

        Log($"Question: '{question2}'");
        var answer2 = await chat.AskAsync(question2);
        Log($"Answer: '{answer2.Data.Content}'");

        Assert.False(IsNullOrWhiteSpace(answer1.Data.Content));
        Assert.False(IsNullOrWhiteSpace(answer2.Data.Content));
    }

    [Fact]
    public async Task AskMultiple_Success()
    {
        var chat = _client.OpenChat();
        var question = "Distance to the sun?";

        Log($"Question: '{question}'");
        var answer = await chat.AskMultipleAsync(question, 3);

        foreach (var chatMessage in answer.Data)
        {
            Log($"Answer: '{chatMessage.Content}'");
            Assert.False(IsNullOrWhiteSpace(chatMessage.Content));
        }
    }


    [Fact]
    public async Task ChatSessionSaveLoad_Success()
    {
        var chat = _client.OpenChat();
        var question = "Distance to the sun?";

        await chat.AskAsync(question);
        var sessionJson = chat.Session.ToJson();
        Log($"Session json: '{sessionJson}'");

        var newChat = _client.OpenChat(x => x.FromJson(sessionJson));
        var loadedSessionJson = newChat.Session.ToJson();
        Log($"Loaded session json: '{loadedSessionJson}'");


        Assert.Equal(sessionJson, loadedSessionJson);
    }

    private void Log(string message)
    {
        _output.WriteLine(message);
    }


}