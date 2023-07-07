using FluentAssertions;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class CommonTests
{
    private readonly ITestOutputHelper _output;


    public CommonTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task UploadFile_Success()
    {
        var enumValue = GptModel.Gpt40613;
        var enumName = enumValue.Name(); // Enum.GetName(enumValue);
        enumName.Should().Be("gpt-4-0613");
    }
}