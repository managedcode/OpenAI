using ManagedCode.OpenAI.Client.Exceptions;
using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Models;

public static class ModelMethods
{
    public const string URL_LIST_MODELS = "https://api.openai.com/v1/models";
    public const string URL_MODEL = "https://api.openai.com/v1/models/{0}";
    
    public static async Task<ListModels> GetModels(this OpenAIClient client)
    {
        var httpResponseMessage = await client.GetAsync(URL_LIST_MODELS);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);
        
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<ListModels>(responseBody);
    }
    
    public static async Task<Model> GetModel(this OpenAIClient client, string id)
    {
        var httpResponseMessage = await client.GetAsync(
            string.Format(URL_MODEL, id));

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);
        
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Model>(responseBody);
    }
}