using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Completions;

public class CompletionsBuilder
{
    public const string URL_COMPLETIONS = "completions";

    private OpenAIClient _client;
    private CompletionRequest _completion;

    public CompletionsBuilder(OpenAIClient client, string modelId)
    {
        this._client = client;
        _completion = new CompletionRequest()
        {
            Model = modelId
        };
    }

    public CompletionsBuilder SetPrompt(string prompt)
    {
        if (prompt.Length > 1024)
            throw new ArgumentException();

        _completion.Prompt = new string[] { prompt };

        return this;
    }

    public CompletionsBuilder SetPrompt(string[] prompt)
    {
        _completion.Prompt = prompt;

        return this;
    }

    public CompletionsBuilder SetSuffix(string suffix)
    {
        _completion.Suffix = suffix;

        return this;
    }

    public CompletionsBuilder SetMaxTokens(int maxTokens)
    {
        if (maxTokens is < 0 or > 2048)
            throw new ArgumentOutOfRangeException();

        _completion.MaxTokens = maxTokens;

        return this;
    }

    public CompletionsBuilder SetTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _completion.Temperature = temperature;

        return this;
    }

    public CompletionsBuilder SetRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _completion.N = count;

        return this;
    }

    public CompletionsBuilder UseStream()
    {
        _completion.Stream = true;

        return this;
    }

    public CompletionsBuilder SetLogProbs(int count)
    {
        if (count is < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        _completion.Logprobs = count;

        return this;
    }

    public CompletionsBuilder UseEcho()
    {
        _completion.Echo = true;

        return this;
    }

    public CompletionsBuilder SetStop(string stop)
    {
        _completion.Stop = new string[] { stop };

        return this;
    }

    public CompletionsBuilder SetStop(string[] stop)
    {
        if (stop.Length > 4)
            throw new ArgumentOutOfRangeException();

        _completion.Stop = stop;

        return this;
    }

    public CompletionsBuilder SetPresencePenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _completion.PresencePenalty = number;

        return this;
    }

    public CompletionsBuilder SetFrequencyPenalty(float number)
    {
        if (number is < -2f or > 2f)
            throw new ArgumentOutOfRangeException();

        _completion.FrequencyPenalty = number;

        return this;
    }

    public CompletionsBuilder SetBestOf(int integer)
    {
        if (integer <= 0)
            throw new ArgumentOutOfRangeException();

        if (_completion.Stream == true)
        {
            throw new NotSupportedException("Results cannot be streamed.");
        }

        _completion.BestOf = integer;

        return this;
    }

    public CompletionsBuilder SetLogitBias(Dictionary<string, int> dictionary)
    {
        _completion.LogitBias = dictionary;

        return this;
    }

    public CompletionsBuilder AddLogitBias(string key, int value)
    {
        var dict = _completion.LogitBias ??= new Dictionary<string, int>();

        dict.Add(key, value);

        return this;
    }

    public CompletionsBuilder SetUser(string user)
    {
        _completion.User = user;

        return this;
    }


    public async Task<CompletionResult> Send()
    {
        var json = JsonSerializer.Serialize(_completion);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var httpResponseMessage = await _client.PostAsync(
            URL_COMPLETIONS, content);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<CompletionResult>(responseBody);

        return result;
    }

    public CompletionsBuilder Clear(string modelId)
    {
        _completion = new CompletionRequest()
        {
            Model = modelId
        };

        return this;
    }

    public CompletionsBuilder Clear(Model model)
    {
        return Clear(model.Id);
    }
}