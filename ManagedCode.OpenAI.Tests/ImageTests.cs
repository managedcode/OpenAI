using ManagedCode.OpenAI.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Image;
using Xunit;
using Xunit.Abstractions;
using ManagedCode.OpenAI.Image.Extensions;

namespace ManagedCode.OpenAI.Tests
{
    public class ImageTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IGptClient _client = Mocks.Client();

        public ImageTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task GenerateImage_Success()
        {
            var image = await _client.GenerateImage("Red dragon")
                .SetImageResolution(ImageResolution._512x512).GenerateAsync();

            Log($"Image url: {image.Content}");
            Assert.False(string.IsNullOrWhiteSpace(image.Content));
        }

        [Fact]
        public async Task EditImage_Success()
        {
           var edited = await _client
               .EditImage("change color to blue",
                   x=> x.FromBytes(Properties.Resources.Dog))
               .AsUrl()
               .EditAsync();

           Log($"Edited dog: {edited}");
           Assert.False(string.IsNullOrWhiteSpace(edited.Content));
        }

        private void Log(string message)
        {
            _output.WriteLine(message);
        }
    }
}
