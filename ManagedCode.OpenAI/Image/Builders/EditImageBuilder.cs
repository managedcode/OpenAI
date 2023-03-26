using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Extensions;
using ManagedCode.OpenAI.Image.Extensions;

namespace ManagedCode.OpenAI.Image.Builders
{
    internal class EditImageBuilder : BaseImageBuilder<IEditImageBuilder, EditImageRequestDto>,
        IEditImageBuilder
    {
        private readonly IOpenAiWebClient _webClient;

        public EditImageBuilder(IOpenAiWebClient webClient, string instruction, string imageB64)
        {
            _webClient = webClient;
            Request.Description = instruction;
            Request.ImageBase64 = imageB64;
        }

        protected override IEditImageBuilder Builder()
        {
            return this;
        }

        public IEditImageBuilder SetImageMask(string base64)
        {
            Request.MaskBase64 = base64;
            return this;
        }

        public async Task<IGptImage<string>> EditAsync()
        {
            Request.Validate();
            var response = await _webClient.EditImageAsync(Request);
            return response.AsSingle();
        }

        public async Task<IGptImage<string[]>> EditMultipleAsync(int count)
        {
            Request.Validate();
            var response = await _webClient.EditImageAsync(Request);
            return response.AsMultiple();
        }
    }
}
