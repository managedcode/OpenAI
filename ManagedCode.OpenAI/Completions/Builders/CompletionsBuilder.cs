using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Completions.Enums;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Completions;

public class CompletionsBuilder
{
    

    private OpenAIClient _client;
    private CompletionRequestOptions _option;
    private PromptConfig _promptConfig = PromptConfig.None;
    
    
    public CompletionsBuilder(OpenAIClient client, CompletionModel modelId)
    {
        this._client = client;
        _option = new CompletionRequestOptions()
        {
            Model = modelId
        };
    }

    public CompletionsBuilder WithPrompt(string prompt)
    {
        if (prompt.Length > 1024)
            throw new ArgumentException();

        _option.Prompt.Add(prompt);

        return this;
    }

    public CompletionsBuilder WithPrompt(IEnumerable<string> prompt)
    {
        _option.Prompt.AddRange(prompt);

        return this;
    }

    public CompletionsBuilder WithSuffix(string suffix)
    {
        _option.Suffix = suffix;

        return this;
    }

    public CompletionsBuilder WithMaxTokens(int maxTokens)
    {
        if (maxTokens is < 0 or > 2048)
            throw new ArgumentOutOfRangeException();

        _option.MaxTokens = maxTokens;

        return this;
    }

    public CompletionsBuilder WithTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _option.Temperature = temperature;

        return this;
    }

    public CompletionsBuilder WithResultCount(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _option.N = count;

        return this;
    }

    public CompletionsBuilder WithStream()
    {
        _option.Stream = true;

        return this;
    }

    public CompletionsBuilder WithLogProbs(int count)
    {
        if (count is < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        _option.Logprobs = count;

        return this;
    }

    public CompletionsBuilder WithEcho()
    {
        _option.Echo = true;

        return this;
    }

    public CompletionsBuilder WithStop(string stop)
    {
        _option.Stop = new string[] { stop };

        return this;
    }

    public CompletionsBuilder SetStop(string[] stop)
    {
        if (stop.Length > 4)
            throw new ArgumentOutOfRangeException();

        _option.Stop = stop;

        return this;
    }

    public CompletionsBuilder WithPresencePenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _option.PresencePenalty = number;

        return this;
    }

    public CompletionsBuilder WithFrequencyPenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _option.FrequencyPenalty = number;

        return this;
    }

    public CompletionsBuilder WithBestOf(int integer)
    {
        if (integer <= 0)
            throw new ArgumentOutOfRangeException();

        if (_option.Stream == true)
        {
            throw new NotSupportedException("Results cannot be streamed.");
        }

        _option.BestOf = integer;

        return this;
    }

    public CompletionsBuilder SetLogitBias(Dictionary<string, int> dictionary)
    {
        _option.LogitBias = dictionary;

        return this;
    }

    public CompletionsBuilder AddLogitBias(string key, int value)
    {
        var dict = _option.LogitBias ??= new Dictionary<string, int>();

        dict.Add(key, value);

        return this;
    }

    public CompletionsBuilder WithUsername(string user)
    {
        _option.User = user;

        return this;
    }

    public CompletionsBuilder AllowResetPrompt() => WithPromptConfig(PromptConfig.Reset);
    public CompletionsBuilder AllowUpdatePrompt() => WithPromptConfig(PromptConfig.Update);
    public CompletionsBuilder AllowUpdateAndAppendPrompt() => WithPromptConfig(PromptConfig.AppendAndUpdate);

    
    public CompletionsBuilder WithPromptConfig(PromptConfig update)
    {

        if (((_promptConfig | update) & PromptConfig.AppendAndUpdate) == PromptConfig.Append)
            throw new ArgumentException(
                "Cannot only append to prompt. Using AppendAndUpdate or Update.", 
                nameof(update)
                );
        
        _promptConfig |= update;

        return this;
    }

    public CompletionsBuilder Clear()
    {
        _option = new CompletionRequestOptions()
        {
            Model = _option.Model
        };

        return this;
    }

    public CompletionManager Create()
    {
        return new CompletionManager(_client, _option.DeepClone(), _promptConfig);
    }

}