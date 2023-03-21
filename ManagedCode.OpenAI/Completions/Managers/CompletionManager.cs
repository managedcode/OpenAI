using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using ManagedCode.OpenAI.Chats;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Completions.Enums;
using ManagedCode.OpenAI.Exceptions;

namespace ManagedCode.OpenAI.Completions;

public class CompletionManager
{
    private const string URL_COMPLETIONS = "completions";
    
    private OpenAIClient _client;
    private CompletionRequestOptions _option;
    private int _promptCount;
    private PromptConfig _promptConfig;

    public CompletionManager(OpenAIClient client, CompletionRequestOptions option, PromptConfig promptConfig)
    {
        _client = client;
        _option = option;
        _promptCount = option.Prompt.Count;
        _promptConfig = promptConfig;
    }

    public CompletionManager Prompt(string startWith)
    {
        _option.Prompt.Add(startWith);

        return this;
    }
    
    public CompletionManager Prompt(IEnumerable<string> startWith)
    {
        _option.Prompt.AddRange(startWith);

        return this;
    }
    

    public async Task<CompletionResult> GetResultAsync()
    {
        var httpResponseMessage = await _client.PostAsJsonAsync(URL_COMPLETIONS, _option);

        // TODO: Check model and other errors
        OpenAIExceptions.ThrowsIfError(httpResponseMessage.StatusCode);

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<CompletionResult>(responseBody);
        
        Debug.Print(responseBody);

        RefreshData(result);

        return result; 
    }

    private void RefreshData(CompletionResult result)
    {  
        if((_promptConfig & PromptConfig.Reset) == PromptConfig.Reset)
            ResetPromps();

        if ((_promptConfig & PromptConfig.Update) == PromptConfig.Update)
            UpdatePrompt(result);
    }

    private void ResetPromps(){
        _option.Prompt.RemoveRange(_promptCount, _option.Prompt.Count - _promptCount);
    }
    
    private void UpdatePrompt(CompletionResult result)
    {
        if ((_promptConfig & PromptConfig.Append) == PromptConfig.Append)
        {
            for (int i = 0, len = _option.Prompt.Count; i < len; i++)
            {
                string str = _option.Prompt[i];
                _option.Prompt[i] = str + result.Choices[i].Text;
            }
        }
        else
        {
            for (int i = 0, len = _option.Prompt.Count; i < len; i++)
            {
                _option.Prompt[i] = result.Choices[i].Text;
            } 
        }

    }
}