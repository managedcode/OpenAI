using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.API.Image;

namespace ManagedCode.OpenAI.API
{
    internal interface IOpenAiWebClient : IDisposable
    {
        public Task<ModelsResponseDto> ModelsAsync();

        public Task<ModelDto> ModelAsync(string modelId);

        Task<ChatResponseDto> ChatAsync(ChatRequestDto request);

        Task<CompletionResponseDto> CompletionsAsync(CompletionRequestDto request);

        Task<EditResponseDto> EditAsync(EditRequestDto request);

        Task<ImageResponseDto> GenerateImageAsync(GenerateImageRequestDto request);
        Task<ImageResponseDto> EditImageAsync(EditImageRequestDto request);
        Task<ImageResponseDto> VariationImageAsync(VariationImageRequestDto request);
    }
}
