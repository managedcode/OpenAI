using FluentAssertions;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests
{
    public class EditTests: BaseTestClass
    {
        public EditTests(ITestOutputHelper output, IConfiguration configuration) 
            : base(output, configuration)
        {
        }

        [ManualTest]
        public async Task EditMessage_Success()
        {
            var client = ClientBuilder.Build();
            var result = await client.Edit($"AABBAADD", 
                    "Remove all 'A' symbols from string")
                .ExecuteAsync();

            result.Data.Content.Trim().Should().BeEquivalentTo("BBDD");
        }
    }
}
