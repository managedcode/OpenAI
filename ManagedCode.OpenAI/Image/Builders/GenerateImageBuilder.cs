using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Image;

internal class GenerateImageBuilder :
    BaseImageBuilder<IGenerateImageBuilder, GenerateImageRequestDto>,
    IGenerateImageBuilder
{
    private readonly IOpenAiWebClient _webClient;

    public GenerateImageBuilder(IOpenAiWebClient webClient, string description)
    {
        _webClient = webClient;
        Request.Description = description;
    }

    public async Task<IGptImage<string>> ExecuteAsync()
    {
        Request.Validate();
        var response = await _webClient.GenerateImageAsync(Request);
        return response.AsSingle();
    }

    public async Task<IGptImage<string[]>> ExecuteMultipleAsync(int count)
    {
        Request.N = count;
        Request.Validate();
        var response = await _webClient.GenerateImageAsync(Request);
        return response.AsMultiple();
    }

    protected override IGenerateImageBuilder Builder()
    {
        return this;
    }
}