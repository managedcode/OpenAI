using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Image;

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

    public IEditImageBuilder SetImageMask(string base64)
    {
        Request.MaskBase64 = base64;
        return this;
    }

    public async Task<IGptImage<string>> ExecuteAsync()
    {
        Request.Validate();
        var response = await _webClient.EditImageAsync(Request);
        return response.AsSingle();
    }

    public async Task<IGptImage<string[]>> ExecuteMultipleAsync(int count)
    {
        Request.Validate();
        var response = await _webClient.EditImageAsync(Request);
        return response.AsMultiple();
    }

    protected override IEditImageBuilder Builder()
    {
        return this;
    }
}