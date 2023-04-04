using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Image
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
