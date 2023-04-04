using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ManagedCode.OpenAI.API;

namespace ManagedCode.OpenAI.Image
{
    internal class ImageClient: IImageClient
    {
        private readonly IOpenAiWebClient _webClient;

        public ImageClient(IOpenAiWebClient webClient)
        {
            _webClient = webClient;
        }

        public IGenerateImageBuilder GenerateImage(string description)
        {
            return new GenerateImageBuilder(_webClient, description);
        }

        public IEditImageBuilder EditImage(string description, string imageBase64)
        {
            return new EditImageBuilder(_webClient, description, imageBase64);
        }

        public IVariationImageBuilder VariationImage(string imageBase64)
        {
            return new VariationImageBuilder(_webClient, imageBase64);
        }
    }
}
