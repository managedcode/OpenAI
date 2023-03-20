using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Editor.Enums;
using ManagedCode.OpenAI.Exceptions;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Editor;

public class EditRequestBuilder
{
    public const string URL_EDITS = "edits";

    private OpenAIClient _client;
    private EditRequestOptions _options = new EditRequestOptions();

    public EditRequestBuilder(OpenAIClient client, EditModel model)
    {
        _client = client;
        _options.Model = model;
    }
    
    public EditRequestBuilder(OpenAIClient client, EditModel model, string instruction) 
        : this(client, model)
    {
        _options.Instruction = instruction;
    }


    public EditRequestBuilder WithInput(string input)
    {
        _options.Input = input;

        return this;
    }

    public EditRequestBuilder WithRequestResult(int count)
    {
        if (count is < 0)
            throw new ArgumentOutOfRangeException();

        _options.N = count;

        return this;
    }

    public EditRequestBuilder WithTemperature(float temperature)
    {
        if (temperature is < 0f or > 2)
            throw new ArgumentOutOfRangeException();

        _options.Temperature = temperature;

        return this;
    }

    public EditRequestBuilder WithTopP(float topP)
    {
        _options.TopP = topP;

        return this;
    }


    public EditRequestBuilder Clear()
    {
        _options = new EditRequestOptions()
        {
            Model = _options.Model,
            Instruction = _options.Instruction
        };

        return this;
    }

    public EditRequestManager Create()
    {
        return new EditRequestManager(_client, _options);

    }
}