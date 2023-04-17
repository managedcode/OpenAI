using FluentAssertions;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests
{
    public class CompletionTests : BaseTestClass
    {
        public CompletionTests(ITestOutputHelper output, IConfiguration configuration)
            : base(output, configuration)
        {
        }

        [ManualTest]
        public async Task CreateCompletion_Success()
        {
            var client = ClientBuilder.Build();
            var result = await client
                .Completion("Say this is a test")
                .ExecuteAsync();

            result.Data.Content.Should().NotBeNullOrWhiteSpace();
        }
    }
}
