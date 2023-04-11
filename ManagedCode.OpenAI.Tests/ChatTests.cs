using FluentAssertions;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using Moq;
using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using static System.String;

namespace ManagedCode.OpenAI.Tests;

public class ChatTests
{
    private const string SKIP = $"Class {nameof(ChatTests)} disabled";
    private readonly IGptClient _client = Mocks.Client();
    private readonly ITestOutputHelper _output;

    public ChatTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact(Skip = SKIP)]
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

    [Fact(Skip = SKIP)]
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


    [Fact(Skip = SKIP)]
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


    [Fact]
    public async Task GetModels_Success()
    {
        var mock = new Mock<IOpenAiWebClient>();
        var models = new ModelDto[]
        {
            new()
            {
                Id = "mango",
                Permission = new PermissionDto[]
                {
                    new PermissionDto()
                    {
                        AllowCreateEngine = true,
                    }
                }
            }
        };

        mock.Setup(x => x.ModelsAsync())
            .ReturnsAsync
            (new ModelsResponseDto()
                {
                    Models = models
                }
            );

        var client = new GptClient(mock.Object);
        var response = await client.GetModelsAsync();
        var expected = models.Select(selector: x => x.ToModel()).ToArray();

        expected.Should().BeEquivalentTo(response);
    }

    [Fact]
    public async Task GetModels_Empty()
    {
        var mock = new Mock<IOpenAiWebClient>();

        var models = new ModelDto[]
       {    };
        mock.Setup(x => x.ModelsAsync())
            .ReturnsAsync(new ModelsResponseDto()
            {
                Models = models
            });  

        var client = new GptClient(mock.Object);
        var response = await client.GetModelsAsync(); 
        response.Should().BeEmpty();
    }


    [Fact]
    public async Task GetModel_Success()
    {

        var mock = new Mock<IOpenAiWebClient>();
        var model = new ModelDto
        {
            Id = "obj",
            Permission = new PermissionDto[]
            {
                new PermissionDto()
                {
                    AllowCreateEngine = true,
                }
            }
        };

        mock.Setup(x => x.ModelAsync("obj"))
            .ReturnsAsync(model);

        var client = new GptClient(mock.Object);
        var response = await client.GetModelAsync(model.Id);
        var expected = model.ToModel();

        expected.Should().BeEquivalentTo(response);

    }

    [Fact]
    public async Task GetModel_NullException()
    {
        var mock = new Mock<IOpenAiWebClient>();
        var model = new ModelDto
        {
            Id = "obj",
            Permission = new PermissionDto[]
           {
                new PermissionDto()
                {
                    AllowCreateEngine = true,
                }
           }
        };

        mock.Setup(x => x.ModelAsync("obj"))
            .ReturnsAsync(model);

        var client = new GptClient(mock.Object);
        await Assert.ThrowsAsync<NullReferenceException>(async () => await client.GetModelAsync("model"));
    }

}