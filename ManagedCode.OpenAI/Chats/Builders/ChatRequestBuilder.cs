using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Chats.Enums;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Chats;

public class ChatRequestBuilder
{
    private OpenAIClient _client;
    private ChatRequestOptions _option;

    public ChatRequestBuilder(OpenAIClient client, ChatModel model)
    {
        this._client = client;
        _option = new ChatRequestOptions()
        {
            Model = model
        };
    }

    public ChatRequestBuilder AskUser(string text)
    {
        _option.Messages.Add(new Message(RoleType.user, text));

        return this;
    }
    
    public ChatRequestBuilder AskAssistant(string text)
    {
        _option.Messages.Add(new Message(RoleType.assistant, text));

        return this;
    }
    
    


    public ChatRequestBuilder WithMaxTockens(int maxTokens)
    {
        if (maxTokens is < 0 or > 2048)
            throw new ArgumentOutOfRangeException();

        _option.MaxTokens = maxTokens;

        return this;
    }

    public ChatRequestBuilder WithTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _option.Temperature = temperature;

        return this;
    }

    public ChatRequestBuilder WithNucleus(float value)
    {
        _option.TopP = value;

        return this;
    }

    public ChatRequestBuilder WithResultCount(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _option.N = count;

        return this;
    }

    public ChatRequestBuilder WithStream()
    {
        _option.Stream = true;

        return this;
    }


    public ChatRequestBuilder WithPresencePenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _option.PresencePenalty = number;

        return this;
    }

    public ChatRequestBuilder WithFrequencyPenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _option.FrequencyPenalty = number;

        return this;
    }


    public ChatRequestBuilder WithLogitBias(Dictionary<string, int> dictionary)
    {
        _option.LogitBias = dictionary;

        return this;
    }

    public ChatRequestBuilder AddLogitBias(string key, int value)
    {
        var dict = _option.LogitBias ??= new Dictionary<string, int>();

        dict.Add(key, value);

        return this;
    }

    public ChatRequestBuilder WithUsername(string user)
    {
        _option.User = user;

        return this;
    }


    public ChatRequestBuilder Reset()
    {
        _option = new ChatRequestOptions()
        {
            Model = _option.Model
        };

        return this;
    }
    
    public ChatRequestManager Create()
    {
        
        return new ChatRequestManager(_option.DeepClone(), _client);;
    }
}