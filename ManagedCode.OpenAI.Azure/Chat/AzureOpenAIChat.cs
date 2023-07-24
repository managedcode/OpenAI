using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ChatMessage = Azure.AI.OpenAI.ChatMessage;

namespace ManagedCode.OpenAI.Azure.Chat;

public class AzureOpenAIChat : IOpenAiChat
{
    private readonly OpenAIClient _client;
    private readonly IOpenAiClientConfiguration _configuration;
    private readonly IChatMessageParameters _parameters;
    private ChatCompletionsOptions _options;
    
    public AzureOpenAIChat(OpenAIClient client, IOpenAiClientConfiguration configuration, IChatMessageParameters parameters, IChatSession session)
    {
        _client = client;
        _configuration = configuration;
        _parameters = parameters;
        Session = session;
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
    
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message)
    {
        return await AskAsync(message, _parameters);
    }
    
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters)
    {
        Session.AddRecord( new ChatSessionRecord() { Content = message, Role = _parameters.Role ?? RoleType.User});
        
        _options.Messages.Clear();
        foreach (var record in Session.Records())
        {
            _options = ToAzureOptions(record);
        }
        
        Response<ChatCompletions> response = await _client.GetChatCompletionsAsync(_configuration.ModelId, _options);

        ChatCompletions completions  = response.Value;
        AddRecord(completions);

        return response.Value.ToChatAnswer();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers)
    {
        throw new NotSupportedException("Will be implemented in future versions");
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers, IChatMessageParameters parameters)
    {
        throw new NotSupportedException("Will be implemented in future versions");
    }

    public async Task<IAnswer<IChatMessage>> AskMultipleAsync(IChatSessionRecord[] records, IChatMessageParameters parameters)
    {
        Session.AddRecords(records);
        
        Response<ChatCompletions> response = await _client.GetChatCompletionsAsync(_configuration.ModelId, ToAzureOptions(records));

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
        var role = completions.Choices[0].Message.Role;
        Session.AddRecord(new ChatSessionRecord()
        {
            Content = content, 
            Role = role.GetRole()
        });
    }

    private ChatMessage ToChatMessage(IChatSessionRecord record)
    {
        return new ChatMessage(record.Role.GetRole(), record.Content);
    }
}