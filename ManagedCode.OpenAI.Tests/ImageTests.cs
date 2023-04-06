using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Image;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests
{
    public class ImageTests
    {
        private const string SKIP = $"Class {nameof(ImageTests)} disabled";
        private readonly ITestOutputHelper _output;
        private readonly IGptClient _client = Mocks.Client();

        public ImageTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(Skip = SKIP)]
        public async Task GenerateImage_Success()
        {
            var image = await _client.ImageClient.GenerateImage("Red dragon")
                .SetImageResolution(ImageResolution._512x512).ExecuteAsync();

            Log($"Image url: {image.Content}");
            Assert.False(string.IsNullOrWhiteSpace(image.Content));
        }

        [Fact(Skip = SKIP)]
        public async Task EditImage_Success()
        {
           var edited = await _client
               .ImageClient.EditImage("change color to blue",
                   x=> x.FromBytes(Properties.Resources.Dog))
               .AsUrl()
               .ExecuteAsync();

           Log($"Edited dog: {edited}");
           Assert.False(string.IsNullOrWhiteSpace(edited.Content));
        }

        private void Log(string message)
        {
            _output.WriteLine(message);
        }
    }
}
