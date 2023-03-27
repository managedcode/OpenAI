using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Files.Models;

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

        #region Files

        Task<FilesInfoResponseDto> FilesInfoAsync();
        Task<FileInfoDto> CreateFileAsync(HttpContent content, string fileName, string purpose = "fine-tune");
        Task<FileDeleteResponseDto> DeleteFileAsync(string fileId);
        Task<FileInfoDto> FileInfoAsync(string fileId);
        
        // TODO: This may be a stream
        // I don't know what response type is returned here
        Task<string> GetContentFromFileAsync(string fileId);

        #endregion
    }
}