using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Image
{
    internal class GenerateImageRequestDto: BaseImageRequestDto
    {
        [JsonPropertyName("prompt")]
        public string Description { get; set; }

        

    }
}
