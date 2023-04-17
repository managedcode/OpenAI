using FluentAssertions;
using ManagedCode.OpenAI.API.Errors;
using ManagedCode.OpenAI.Extensions;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using ManagedCode.OpenAI.Tests.Extensions;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests
{
    public class ModelsTests : BaseTestClass
    {
        public ModelsTests(ITestOutputHelper output, IConfiguration configuration)
            : base(output, configuration)
        {

        }

        [ManualTest]
        public async Task GetModel_ModelNotFoundException()
        {
            var modelName = "WRONG_MODEL_NAME";
            var client = ClientBuilder.Build();

            await client.Invoking(async x => await x.GetModelAsync(modelName))
                .Should().ThrowAsync<OpenAIException>()
                .Where(x => x.ErrorCode
                    .Is(OpenAIErrorCode.ModelNotFound.Name()));
        }

        [ManualTest]
        public async Task GetModel_Success()
        {
            var modelName = "babbage";
            var client = ClientBuilder.Build();
            var model = await client.GetModelAsync(modelName);
            model.Id.Should().Be(modelName);
        }

        [ManualTest]
        public async Task GetModels_Success()
        {
            var expectedModels = new[] { "babbage", "davinci", "text-davinci-edit-001" };
            var client = ClientBuilder.Build();

            var models = await client.GetModelsAsync();
            models.Select(x => x.Id).ToList().Should()
                .Contain(expectedModels);
        }
    }
}
