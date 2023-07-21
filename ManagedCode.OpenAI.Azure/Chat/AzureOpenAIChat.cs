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
    }

    public IChatSession Session { get; }
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message)
    {
        return await AskAsync(message, _parameters);
    }

    public async Task<IAnswer<IChatMessage>> AskAsync(string message, ChatRole role)
    {
        _session.AddRecord(new ChatSessionRecord(){ Content = message, Role = role.ToString() });

        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(_parameters, _session));

        ChatCompletions completions  = response.Value;
        string fullresponse = completions.Choices[0].Message.Content;
        _session.AddRecord(new ChatSessionRecord(){Content = completions.Choices[0].Message.Content, Role = role.ToString() });

        return response.Value.ToChatAnswer();
    }
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters)
    {
        _session.AddRecord(new ChatSessionRecord(){ Content = message, Role = _parameters.Role });
        
        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(_parameters, _session));

        ChatCompletions completions  = response.Value;
        _session.AddRecord(new ChatSessionRecord(){Content = completions.Choices[0].Message.Content, Role = parameters.Role });

        return response.Value.ToChatAnswer();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers)
    {
        throw new NotImplementedException();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers, IChatMessageParameters parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<IAnswer<IChatMessage>> AskMultipleAsync(IChatSessionRecord[] records, IChatMessageParameters parameters)
    {
        _session.AddRecords(records);
        
        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                _configuration.ModelId,
                ToAzureOptions(_parameters, _session));

        ChatCompletions completions  = response.Value;
        string fullresponse = completions.Choices[0].Message.Content;
        _session.AddRecord(new ChatSessionRecord(){Content = completions.Choices[0].Message.Content, Role = parameters.Role });

        return response.Value.ToChatAnswer();
    }


    private ChatCompletionsOptions ToAzureOptions(IChatMessageParameters parameters, IChatSession session)
    {
        var chatOptions = new ChatCompletionsOptions()
        {
            MaxTokens = parameters.MaxTokens,
            Temperature = parameters.Temperature,
            FrequencyPenalty = parameters.FrequencyPenalty,
            PresencePenalty = parameters.PresencePenalty,
            NucleusSamplingFactor = parameters.NucleusSamplingFactor
        };
        
        foreach(var message in session.Records())
        {
            var chatMessage = new ChatMessage(message.Role, message.Content);
            chatOptions.Messages.Add(chatMessage);
        }

        return chatOptions;
    }
}