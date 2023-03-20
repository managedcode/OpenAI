using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using ManagedCode.OpenAI.Chats.Enums;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Exceptions;

namespace ManagedCode.OpenAI.Chats;

public class ChatRequestManager
{
    private const string URL_COMPLETIONS = "chat/completions";
    
    private OpenAIClient _client;
    private ChatRequestOption _option;

    public ChatRequestManager(ChatRequestOption option, OpenAIClient client)
    {
        _option = option;
        _client = client;
    }

    public ChatRequestManager Ask(string message)
    {
        _option.Messages.Add(new Message(RoleType.user, message));

        return this;
    }

    public async Task<ChatResult> GetResultAsync()
    {
        var httpResponseMessage = await _client.PostAsJsonAsync(URL_COMPLETIONS, _option);

        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ChatResult>(responseBody);

        //TODO: check model
        _option.Messages.AddRange(result.Choices.Select(e => e.Message));

        return result;

    } 
    
    

}