using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Extensions;
using ManagedCode.OpenAI.Image.Extensions;

namespace ManagedCode.OpenAI.Image.Builders
{
    internal class GenerateImageBuilder :
        BaseImageBuilder<IGenerateImageBuilder, GenerateImageRequestDto>,
        IGenerateImageBuilder
    {
        private readonly IOpenAiWebClient _webClient;

        public GenerateImageBuilder(IOpenAiWebClient webClient, string description)
        {
            _webClient = webClient;
            Request.Description = description;
        }

        public async Task<IGptImage<string>> GenerateAsync()
        {
            Request.Validate();
            var response = await _webClient.GenerateImageAsync(Request);
            return response.AsSingle();
        }

        public async Task<IGptImage<string[]>> GenerateMultipleAsync(int count)
        {
            Request.Validate();
            var response = await _webClient.GenerateImageAsync(Request);
            return response.AsMultiple();
        }

        protected override IGenerateImageBuilder Builder()
        {
            return this;
        }

    }
}
