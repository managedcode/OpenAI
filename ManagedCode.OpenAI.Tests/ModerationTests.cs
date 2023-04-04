using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Moderation;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class ModerationTests
{
    private readonly ITestOutputHelper _output;
    private readonly IGptClient _client = Mocks.Client();
    private IModerationBuilder ModerationBuilder => _client.Moderation();

    public ModerationTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
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

    [Fact]
    public async Task CreateMultipleModeration_Success()
    {
        var moderation = await ModerationBuilder
            .ExecuteMultipleAsync("I kill you", "You are a bad man");

        Assert.NotNull(moderation);

        Assert.Equal(2, moderation.Length);
        
        Log("Moderations have next content:");
        Log(ToJson(moderation));
    }






    void Log(object obj) => Log(obj.ToString());

    void Log(string str) => _output.WriteLine(str);

    string ToJson(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
}