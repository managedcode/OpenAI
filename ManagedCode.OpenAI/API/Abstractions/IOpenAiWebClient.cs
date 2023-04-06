using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.API.File;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.API.Moderation;

namespace ManagedCode.OpenAI.API;

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

    #region Moderations

    Task<ModerationResponseDto> ModerationAsync(ModerationRequestDto request);

    #endregion

    #region Files

    Task<FilesInfoResponseDto> FilesInfoAsync();
    Task<FileInfoDto> CreateFileAsync(string content, string fileName, string purpose = "fine-tune");
    Task<FileInfoDto> CreateFileAsync(Stream content, string fileName, string purpose = "fine-tune");
    Task<FileInfoDto> CreateFileAsync(byte[] content, string fileName, string purpose = "fine-tune");
    Task<FileInfoDto> CreateFileAsync(ReadOnlyMemory<byte> content, string fileName, string purpose = "fine-tune");
    Task<FileDeleteResponseDto> DeleteFileAsync(string fileId);
    Task<FileInfoDto> FileInfoAsync(string fileId);

    // TODO: This may be a stream
    // I don't know what response type is returned here
    Task<string> GetContentFromFileAsync(string fileId);

    #endregion
}