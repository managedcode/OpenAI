using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Completions;

public interface ICompletionBuilder
{
    public ICompletionBuilder AddPrompt(string prompt);
    public ICompletionBuilder AddPrompt(IEnumerable<string> prompt);
    public ICompletionBuilder SetSuffix(string suffix);
    public ICompletionBuilder SetMaxTokens(int maxTokens);
    public ICompletionBuilder SetTemperature(float temperature);
    public ICompletionBuilder SetStream();
    public ICompletionBuilder SetLogProbs(int count);
    public ICompletionBuilder SetEcho();
    public ICompletionBuilder SetStop(string stop);
    public ICompletionBuilder SetStop(string[] stop);
    public ICompletionBuilder SetPresencePenalty(float number);
    public ICompletionBuilder SetFrequencyPenalty(float number);
    public ICompletionBuilder SetBestOf(int integer);
    public ICompletionBuilder SetLogitBias(Dictionary<string, int> dictionary);
    public ICompletionBuilder AddLogitBias(string key, int value);
    public ICompletionBuilder SetUsername(string user);
    public ICompletionBuilder SetModel(string modelId);
    public ICompletionBuilder SetModel(GptModel model);


    public Task<IAnswer<ICompletionsMessage>> ExecuteSingleAsync();

    public Task<IAnswer<ICompletionsMessage[]>> ExecuteMultipleAsync(int count);
}