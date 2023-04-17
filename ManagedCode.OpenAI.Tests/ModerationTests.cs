using FluentAssertions;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using ManagedCode.OpenAI.Tests.Extensions;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class ModerationTests : BaseTestClass
{

    public ModerationTests(ITestOutputHelper output, IConfiguration configuration)
        : base(output, configuration)
    {
    }

    [ManualTest]
    public async Task CreateModeration_Success()
    {
        var client = ClientBuilder.Build();

        var moderation = await client.Moderation().ExecuteAsync("I kill you");

        //assert
        moderation.Categories.Violence.Should().BeTrue();
        moderation.Should().NotBeNull();
        moderation.Categories.Should().NotBeNull();
        moderation.CategoryScores.Should().NotBeNull();

        Log($"Moderation content: {Environment.NewLine}{moderation.ToJson()}");
    }

    [ManualTest]
    public async Task CreateMultipleModeration_Success()
    {
        var client = ClientBuilder.Build();

        var moderationItems = await client.Moderation()
            .ExecuteMultipleAsync("I kill you", "You must die");


        //assert
        moderationItems.Should().NotBeNull().And.HaveCount(2);
        foreach (var moderation in moderationItems)
            moderation.Categories.Violence.Should().BeTrue();

        Log($"Moderation content: {Environment.NewLine}{moderationItems.ToJson()}");
    }
}