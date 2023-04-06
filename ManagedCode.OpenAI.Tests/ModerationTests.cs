using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Moderation;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class ModerationTests
{
    private const string SKIP = $"Class {nameof(ImageTests)} disabled";
    private readonly IGptClient _client = Mocks.Client();
    private readonly ITestOutputHelper _output;

    public ModerationTests(ITestOutputHelper output)
    {
        _output = output;
    }

    private IModerationBuilder ModerationBuilder => _client.Moderation();

    [Fact(Skip = SKIP)]
    public async Task CreateModeration_Success()
    {
        var moderation = await ModerationBuilder
            .ExecuteAsync("I kill you");

        Assert.NotNull(moderation);

        Assert.NotNull(moderation.Categories);
        Assert.NotNull(moderation.CategoryScores);

        Log("Moderation has next content:");
        Log(ToJson(moderation));
    }

    [Fact(Skip = SKIP)]
    public async Task CreateMultipleModeration_Success()
    {
        var moderation = await ModerationBuilder
            .ExecuteMultipleAsync("I kill you", "You are a bad man");

        Assert.NotNull(moderation);

        Assert.Equal(2, moderation.Length);

        Log("Moderations have next content:");
        Log(ToJson(moderation));
    }

    private void Log(object obj)
    {
        Log(obj.ToString());
    }

    private void Log(string str)
    {
        _output.WriteLine(str);
    }

    private string ToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}