using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManagedCode.OpenAI.API.Image
{
    internal class GenerateImageRequestDto: BaseImageRequestDto
    {
        [JsonPropertyName("prompt")]
        public string Description { get; set; }

        

    }
}
