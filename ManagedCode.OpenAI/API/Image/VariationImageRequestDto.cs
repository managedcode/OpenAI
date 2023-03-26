using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManagedCode.OpenAI.API.Image
{
    internal class VariationImageRequestDto: BaseImageRequestDto
    {
        [JsonPropertyName("image")]
        public string ImageBase64 { get; set; }

    }
}
