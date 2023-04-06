using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Chat;

internal class GptChat : IGptChat
{
    private const RoleType DEFAULT_ROLE = RoleType.User;
    private const GptModel DEFAULT_MODEL = GptModel.Turbo;
    private readonly IChatMessageParameters _defaultMessageParameters;

    private readonly IOpenAiWebClient _webClient;

    public GptChat(IOpenAiWebClient webClient, IChatSession session,
        IChatMessageParameters defaultMessageParameters)
    {
        _webClient = webClient;
        _defaultMessageParameters = defaultMessageParameters;
        Session = session;
    }

    public IChatSession Session { get; }

    public async Task<IAnswer<IChatMessage>> AskAsync(string message)
    {
        return await AskAsync(message, _defaultMessageParameters);
    }

    public async Task<IAnswer<IChatMessage>> AskAsync(string message, IChatMessageParameters parameters)
    {
        var askMessage = CreateAskMessage(message, parameters);
        var request = ToChatRequest(askMessage, 1, parameters);

        var response = await _webClient.ChatAsync(request);
        UpdateSession(response, askMessage);
        return response.ToChatAnswer();
    }

    public async Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers)
    {
        return await AskMultipleAsync(message, countOfAnswers, _defaultMessageParameters);
    }

    public async Task<IAnswer<IChatMessage[]>> AskMultipleAsync(string message, int countOfAnswers,
        IChatMessageParameters parameters)
    {
        var askMessage = CreateAskMessage(message, parameters);
        var request = ToChatRequest(askMessage, countOfAnswers, parameters);
        var response = await _webClient.ChatAsync(request);

        UpdateSession(response, askMessage);
        return response.ToChatAnswerCollection();
    }

    private void UpdateSession(ChatResponseDto response, MessageDto askMessage)
    {
        Session.AddRecord(new ChatSessionRecord
        {
            Content = askMessage.Content,
            Role = askMessage.Role
        });

        var responseRecords =
            response.Choices.Select(x => (IChatSessionRecord)new ChatSessionRecord
            {
                Content = x.Message.Content,
                Role = x.Message.Role
            }).ToArray();


        Session.AddRecords(responseRecords);
    }

    private MessageDto CreateAskMessage(string message, IChatMessageParameters parameters)
    {
        return new MessageDto
        {
            Content = message,
            Role = (parameters.Role ?? _defaultMessageParameters.Role) ?? DEFAULT_ROLE.Name()
        };
    }

    private ChatRequestDto ToChatRequest(MessageDto askMessage,
        int countOfAnswers, IChatMessageParameters parameters)
    {
        var messages = Session.Records().Select(x => new MessageDto
        {
            Content = x.Content,
            Role = x.Role
        }).ToList();

        messages.Add(askMessage);

        return new ChatRequestDto
        {
            FrequencyPenalty = parameters.FrequencyPenalty ?? _defaultMessageParameters.FrequencyPenalty,
            LogitBias = parameters.LogitBias ?? _defaultMessageParameters.LogitBias,
            MaxTokens = parameters.MaxTokens ?? _defaultMessageParameters.MaxTokens,
            Model = (parameters.ModelId ?? _defaultMessageParameters.ModelId) ?? DEFAULT_MODEL.Name(),
            N = countOfAnswers,
            PresencePenalty = parameters.PresencePenalty ?? _defaultMessageParameters.PresencePenalty,
            Stream = parameters.Stream ?? _defaultMessageParameters.Stream,
            Temperature = parameters.Temperature ?? _defaultMessageParameters.Temperature,
            TopP = parameters.TopP ?? _defaultMessageParameters.TopP,
            User = parameters.User ?? _defaultMessageParameters.User,
            Messages = messages
        };
    }
}