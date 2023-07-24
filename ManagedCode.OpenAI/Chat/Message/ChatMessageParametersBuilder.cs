using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Chat;

public class ChatMessageParametersBuilder : IChatMessageParametersBuilder
{
    private readonly ChatMessageParameters _parameters;

    public ChatMessageParametersBuilder()
    {
        _parameters = new ChatMessageParameters();
    }

    public IChatMessageParametersBuilder SetModel(string modelId)
    {
        _parameters.ModelId = modelId;
        return this;
    }

    public IChatMessageParametersBuilder SetModel(GptModel model)
    {
        _parameters.ModelId = model.Name();
        return this;
    }

    public IChatMessageParametersBuilder SetRole(RoleType role)
    {
        _parameters.Role = role;
        return this;
    }
    
    public IChatMessageParametersBuilder SetMaxTokens(int maxTokens)
    {
        _parameters.MaxTokens = maxTokens;
        return this;
    }

    public IChatMessageParametersBuilder SetTemperature(float temperature)
    {
        _parameters.Temperature = temperature;
        return this;
    }

    public IChatMessageParametersBuilder SetNucleus(float value)
    {
        _parameters.TopP = value;
        return this;
    }

    public IChatMessageParametersBuilder SetStream()
    {
        _parameters.Stream = true;
        return this;
    }

    public IChatMessageParametersBuilder SetPresencePenalty(float number)
    {
        _parameters.PresencePenalty = number;
        return this;
    }

    public IChatMessageParametersBuilder SetFrequencyPenalty(float number)
    {
        _parameters.FrequencyPenalty = number;
        return this;
    }

    public IChatMessageParametersBuilder SetLogitBias(Dictionary<string, int> dictionary)
    {
        _parameters.LogitBias = dictionary;
        return this;
    }

    public IChatMessageParametersBuilder SetLogitBias(string key, int value)
    {
        var dict = _parameters.LogitBias ??= new Dictionary<string, int>();
        dict.Add(key, value);
        return this;
    }

    public IChatMessageParametersBuilder SetUser(string user)
    {
        _parameters.User = user;
        return this;
    }

    public IChatMessageParameters Build()
    {
        _parameters.Validate();
        return _parameters;
    }
}