using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ChatMessage = Azure.AI.OpenAI.ChatMessage;

namespace ManagedCode.OpenAI.Azure.Chat;

public class AzureOpenAIChat : IOpenAiChat
{
    private OpenAIClient _client;
    private IOpenAiClientConfiguration _configuration;
    private IChatMessageParameters _parameters;
    private IChatSession _session;
    
    public AzureOpenAIChat(OpenAIClient client, IOpenAiClientConfiguration configuration, IChatMessageParameters parameters, IChatSession session)
    {
        _client = client;
        _configuration = configuration;
        _parameters = parameters;
        _session = session;
        _options = new ChatCompletionsOptions()
        {
            MaxTokens = parameters.MaxTokens,
            Temperature = parameters.Temperature,
            FrequencyPenalty = parameters.FrequencyPenalty,
            PresencePenalty = parameters.PresencePenalty,
            NucleusSamplingFactor = parameters.NucleusSamplingFactor
        };
    }

    public IChatSession Session { get; }
    private ChatCompletionsOptions _options { get; }
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message)
    {
        return await AskAsync(message, _parameters);
    }

    public async Task<IAnswer<IChatMessage>> AskAsync(string message, ChatRole role)
    {
        var newRecord = new ChatSessionRecord() { Content = message, Role = role.ToString() };
        _session.AddRecord(newRecord);

        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(newRecord));

        ChatCompletions completions  = response.Value;
        AddRecord(completions);

        return response.Value.ToChatAnswer();
    }
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters)
    {
        var newRecord = new ChatSessionRecord() { Content = message, Role = _parameters.Role };
        _session.AddRecord(newRecord);
        
        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(newRecord));

        ChatCompletions completions  = response.Value;
        AddRecord(completions);

        return response.Value.ToChatAnswer();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers, IChatMessageParameters parameters)
    {
        //will be implemented in future versions
        throw new NotSupportedException();
    }

    public async Task<IAnswer<IChatMessage>> AskMultipleAsync(IChatSessionRecord[] records, IChatMessageParameters parameters)
    {
        _session.AddRecords(records);
        
        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(records));

        ChatCompletions completions  = response.Value;
        AddRecord(completions);

        return response.Value.ToChatAnswer();
    }

    private ChatCompletionsOptions ToAzureOptions(IChatSessionRecord record)
    {
        _options.Messages.Add(ToChatMessage(record));
        return _options;
    }
    
    private ChatCompletionsOptions ToAzureOptions(IChatSessionRecord[] records)
    {
        foreach (var record in records)
        {
            _options.Messages.Add(ToChatMessage(record));
        }
        
        return _options;
    }

    private void AddRecord(ChatCompletions completions)
    {
        var content = completions.Choices[0].Message.Content;
        var role = completions.Choices[0].Message.Role.ToString();
        _session.AddRecord(new ChatSessionRecord()
        {
            Content = content, 
            Role = role
        });
        _options.Messages.Add(new ChatMessage(role, content));
    }

    private ChatMessage ToChatMessage(IChatSessionRecord record)
    {
        return new ChatMessage(record.Role, record.Content);
    }
}