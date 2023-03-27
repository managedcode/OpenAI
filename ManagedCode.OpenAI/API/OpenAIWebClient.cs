using System.Net.Http.Headers;
using ManagedCode.OpenAI.Exceptions;
using System.Net.Http.Json;
using System.Text.Json;
using ManagedCode.OpenAI.API.Edit;
using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Files.Models;

namespace ManagedCode.OpenAI.API;

internal class OpenAiWebClient : IOpenAiWebClient
{
    private const string AUTHORIZATION = "Authorization";
    private const string AUTHORIZATION_FORMAT = "Bearer {0}";
    private const string ORGANIZATION = "OpenAI-Organization";
    private const string URL_BASE = "https://api.openai.com/v1/";
    private const string URL_LIST_MODELS = "models";
    private const string URL_MODEL = "models/{0}";
    private const string URL_CHAT_COMPLETIONS = "chat/completions";
    private const string URL_COMPLETIONS = "completions";
    private const string URL_EDITS = "edits";
    private const string URL_IMAGE_GENERATION = "images/generations";
    private const string URL_IMAGE_EDIT = "images/edits";
    private const string URL_IMAGE_VARIATION = "images/variations";
    
    private const string URL_FILES = "files";
    private const string URL_FILE = "files/{0}";
    private const string URL_FILE_CONTEXT = "files/{0}/content";


    private readonly HttpClient _httpClient;

    public OpenAiWebClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add(AUTHORIZATION,
            string.Format(AUTHORIZATION_FORMAT, apiKey));

        _httpClient.BaseAddress = new Uri(URL_BASE);
    }


    public async Task<ModelsResponseDto> ModelsAsync()
    {
        var httpResponseMessage = await _httpClient.GetAsync(URL_LIST_MODELS);
        return await ReadAsync<ModelsResponseDto>(httpResponseMessage);
    }

    public async Task<ModelDto> ModelAsync(string modelId)
    {
        var httpResponseMessage = await _httpClient.GetAsync(
            string.Format(URL_MODEL, modelId.Trim()));
        return await ReadAsync<ModelDto>(httpResponseMessage);
    }

    public async Task<ChatResponseDto> ChatAsync(ChatRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync(URL_CHAT_COMPLETIONS, request);
        return await ReadAsync<ChatResponseDto>(response);
    }

    public async Task<CompletionResponseDto> CompletionsAsync(CompletionRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync(URL_COMPLETIONS, request);
        return await ReadAsync<CompletionResponseDto>(response);
    }

    public async Task<EditResponseDto> EditAsync(EditRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync(URL_EDITS, request);
        return await ReadAsync<EditResponseDto>(response);
    }

    public async Task<ImageResponseDto> GenerateImageAsync(GenerateImageRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync(URL_IMAGE_GENERATION, request);
        return await ReadAsync<ImageResponseDto>(response);
    }

    public async Task<ImageResponseDto> EditImageAsync(EditImageRequestDto request)
    {
        var imageBytes = Convert.FromBase64String(request.ImageBase64);
        var parameters = ToImageRequestParameters(request);
        using var form = new MultipartFormDataContent();

        foreach (var parameter in parameters)
            form.Add(parameter.Key, parameter.Value);

        form.Add(new StreamContent(new MemoryStream(imageBytes)), "image", "image.png");

        if (!string.IsNullOrWhiteSpace(request.MaskBase64))
        {
            var maskBytes = Convert.FromBase64String(request.MaskBase64);
            form.Add(new StreamContent(new MemoryStream(maskBytes)), "mask", "mask.png");
        }

        form.Add(new StringContent(request.Description), "prompt");


        var response = await _httpClient.PostAsync(URL_IMAGE_EDIT, form);
        return await ReadAsync<ImageResponseDto>(response);
    }

    public async Task<ImageResponseDto> VariationImageAsync(VariationImageRequestDto request)
    {
        var imageBytes = Convert.FromBase64String(request.ImageBase64);

        var parameters = ToImageRequestParameters(request);
        using var form = new MultipartFormDataContent();

        foreach (var parameter in parameters)
            form.Add(parameter.Key, parameter.Value);

        form.Add(new StreamContent(new MemoryStream(imageBytes)), "image", "image.png");

        var response = await _httpClient.PostAsync(URL_IMAGE_EDIT, form);
        return await ReadAsync<ImageResponseDto>(response);
    }


    public void Dispose()
    {
        _httpClient.Dispose();
    }

    private async Task<TModel> ReadAsync<TModel>(HttpResponseMessage response)
    {
        OpenAIExceptions.ThrowsIfError(response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonDeserialize<TModel>(responseBody);
    }

    private TModel JsonDeserialize<TModel>(string jsonStr)
    {
        return JsonSerializer.Deserialize<TModel>(jsonStr)
               ?? throw new NullReferenceException();
    }

    private string JsonSerialize<TModel>(TModel model)
    {
        return JsonSerializer.Serialize(model);
    }

    private Dictionary<StringContent, string> ToImageRequestParameters(BaseImageRequestDto request)
    {
        var result = new Dictionary<StringContent, string>();

        if (!string.IsNullOrWhiteSpace(request.Size))
            result.Add(new StringContent(request.Size), "size");


        if (!string.IsNullOrWhiteSpace(request.ResponseFormat))
            result.Add(new StringContent(request.ResponseFormat), "response_format");


        if (!string.IsNullOrWhiteSpace(request.User))
            result.Add(new StringContent(request.User), "user");

        //todo implement 'N' parameter 
        //if (request.N.HasValue)
        //    result.Add();

        return result;
    }

    #region Files

    
    public async Task<FilesInfoResponseDto> FilesInfoAsync()
    {
        var httpResponseMessage = await _httpClient.GetAsync(URL_FILES);
        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonDeserialize<FilesInfoResponseDto>(responseBody);
    }

    public async Task<FileInfoDto> CreateFileAsync(HttpContent content, string fileName, string purpose = "fine-tune")
    {
        MultipartFormDataContent multipartFormDataContent = new();
        multipartFormDataContent.Add(new StringContent(purpose), "purpose");
        multipartFormDataContent.Add(content, "file", fileName);
        
        var httpResponseMessage = await _httpClient.PostAsync(URL_FILES, multipartFormDataContent);
        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        
        return JsonDeserialize<FileInfoDto>(responseBody);
    }

    public async Task<FileDeleteResponseDto> DeleteFileAsync(string fileId)
    {
        string resultUrl = string.Format(URL_FILE, fileId);
        var httpResponseMessage = await _httpClient.DeleteAsync(resultUrl);
        
        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        return JsonDeserialize<FileDeleteResponseDto>(responseBody);
    }

    public async Task<FileInfoDto> FileInfoAsync(string fileId)
    {
        string resultUrl = string.Format(URL_FILE, fileId);

        var httpResponseMessage = await _httpClient.GetAsync(resultUrl);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonDeserialize<FileInfoDto>(responseBody);
    }

    public async Task<string> GetContentFromFileAsync(string fileId)
    {
        string resultUrl = string.Format(URL_FILE_CONTEXT, fileId);
        var httpResponseMessage = await _httpClient.GetAsync(resultUrl);
        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);
        return await httpResponseMessage.Content.ReadAsStringAsync();
    }

    #endregion
}