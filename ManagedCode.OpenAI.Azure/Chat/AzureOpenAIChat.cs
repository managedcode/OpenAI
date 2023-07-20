using Azure;
using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;
using ChatMessage = Azure.AI.OpenAI.ChatMessage;

namespace ManagedCode.OpenAI.Azure.Chat;

public class AzureOpenAIChat : IOpenAiChat
{
    private readonly ChatRole ChatRole = ChatRole.System;
    
    private OpenAIClient _client;
    private ChatCompletionsOptions _options;
    
    public AzureOpenAIChat(OpenAIClient client, ChatCompletionsOptions options)
    {
        _client = client;
        _options = options;
    }

    public IChatSession Session { get; }
    
    public async Task<IAnswer<IChatMessage>> AskAsync(string message)
    {
        _options.Messages.Add(new ChatMessage(ChatRole, message));

        Response<ChatCompletions> response =
            await _client.GetChatCompletionsAsync(
                "gpt-35-turbo",
                _options);

        ChatCompletions completions  = response.Value;
        string fullresponse = completions.Choices[0].Message.Content;
        _options.Messages.Add(completions.Choices[0].Message);

        return response.Value.ToChatAnswer();
    }

    public Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters)
    {
        throw new NotImplementedException();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers)
    {
        throw new NotImplementedException();
    }

    public Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers, IChatMessageParameters parameters)
    {
        throw new NotImplementedException();
    }
}