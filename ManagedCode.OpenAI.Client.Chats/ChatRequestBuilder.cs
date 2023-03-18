using System.Text;
using ManagedCode.Methods;
using ManagedCode.OpenAI.Client.Exceptions;
using ManagedCode.OpenAI.Client.Models;
using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Chats;

public class ChatRequestBuilder
{
    public const string URL_COMPLETIONS = "https://api.openai.com/v1/chat/completions";

    private OpenAIClient _client;
    private ChatRequest _chat;

    public ChatRequestBuilder(OpenAIClient client, string modelId)
    {
        this._client = client;
        _chat = new ChatRequest()
        {
            Model = modelId
        };
    }

    public ChatRequestBuilder AddMessage(string text)
    {
        _chat.Messages.Add(new Message(RoleType.user.ToString(), text));

        return this;
    }


    public ChatRequestBuilder SetMaxTokens(int maxTokens)
    {
        if (maxTokens is < 0 or > 2048)
            throw new ArgumentOutOfRangeException();

        _chat.MaxTokens = maxTokens;

        return this;
    }

    public ChatRequestBuilder SetTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _chat.Temperature = temperature;

        return this;
    }

    public ChatRequestBuilder SetTopP(int topP)
    {
        _chat.TopP = topP;

        return this;
    }

    public ChatRequestBuilder SetRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _chat.N = count;

        return this;
    }

    public ChatRequestBuilder UseStream()
    {
        _chat.Stream = true;

        return this;
    }


    public ChatRequestBuilder SetPresencePenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _chat.PresencePenalty = number;

        return this;
    }

    public ChatRequestBuilder SetFrequencyPenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _chat.FrequencyPenalty = number;

        return this;
    }


    public ChatRequestBuilder SetLogitBias(Dictionary<string, int> dictionary)
    {
        _chat.LogitBias = dictionary;

        return this;
    }

    public ChatRequestBuilder AddLogitBias(string key, int value)
    {
        var dict = _chat.LogitBias ??= new Dictionary<string, int>();

        dict.Add(key, value);

        return this;
    }

    public ChatRequestBuilder SetUser(string user)
    {
        _chat.User = user;

        return this;
    }


    public async Task<ChatResult> Send()
    {
        var json = JsonConvert.SerializeObject(_chat);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var httpResponseMessage = await _client.PostAsync(
            URL_COMPLETIONS, content);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ChatResult>(responseBody);

        _chat.Messages.AddRange(result.Choices.Select(e => e.Message));
        
        return result;
    }

    public ChatRequestBuilder Clear(string modelId)
    {
        _chat = new ChatRequest()
        {
            Model = modelId
        };

        return this;
    }

    public ChatRequestBuilder Clear(Model model)
    {
        return Clear(model.Id);
    }

    public ChatRequestBuilder Clear(ChatModel model)
    {
        return Clear(model.GetDescription());
    }
    
    public ChatRequestBuilder Clear()
    {
        return Clear(_chat.Model);
    }
}