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
    internal class VariationImageBuilder : BaseImageBuilder<IVariationImageBuilder, VariationImageRequestDto>,
        IVariationImageBuilder
    {
        private readonly IOpenAiWebClient _client;

        public VariationImageBuilder(IOpenAiWebClient client, string imageBase64)
        {
            _client = client;
            Request.ImageBase64 = imageBase64;
        }


        public async Task<IGptImage<string>> VariationAsync()
        {
            Request.Validate();
            var response = await _client.VariationImageAsync(Request);
            return response.AsSingle();
        }

        public async Task<IGptImage<string[]>> VariationsMultipleAsync(int count)
        {
            Request.Validate();
            var response = await _client.VariationImageAsync(Request);
            return response.AsMultiple();
        }

        protected override IVariationImageBuilder Builder()
        {
            return this;
        }
    }
}
