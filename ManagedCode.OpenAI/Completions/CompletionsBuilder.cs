using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Completions.Extensions;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Completions
{
    internal class CompletionsBuilder : ICompletionBuilder
    {
        private readonly CompletionRequestDto _request;
        private readonly IOpenAiWebClient _webClient;

        public CompletionsBuilder(IOpenAiWebClient webClient,  string model)
        {
            _request = new CompletionRequestDto();
            _webClient = webClient;
            SetModel(model);
        }

        public ICompletionBuilder AddPrompt(string prompt)
        {
            if (prompt.Length > 1024)
                throw new ArgumentException();

            _request.Prompt.Add(prompt);
            return this;
        }

        public ICompletionBuilder AddPrompt(IEnumerable<string> prompt)
        {
            _request.Prompt.AddRange(prompt);
            return this;
        }

        public ICompletionBuilder SetSuffix(string suffix)
        {
            _request.Suffix = suffix;
            return this;
        }

        public ICompletionBuilder SetMaxTokens(int maxTokens)
        {
            _request.MaxTokens = maxTokens;
            return this;
        }

        public ICompletionBuilder SetTemperature(float temperature)
        {
            _request.Temperature = temperature;
            return this;
        }

        // TODO: How to work, when stream is true?
        public ICompletionBuilder SetStream()
        {
            _request.Stream = true;
            return this;
        }

        public ICompletionBuilder SetLogProbs(int count)
        {
            _request.Logprobs = count;
            return this;
        }

        public ICompletionBuilder SetEcho()
        {
            _request.Echo = true;
            return this;
        }

        public ICompletionBuilder SetStop(string stop)
        {
            _request.Stop = new string[] { stop };
            return this;
        }

        public ICompletionBuilder SetStop(string[] stop)
        {
          
            _request.Stop = stop;
            return this;
        }

        public ICompletionBuilder SetPresencePenalty(float number)
        {
            _request.PresencePenalty = number;
            return this;
        }

        public ICompletionBuilder SetFrequencyPenalty(float number)
        {
            _request.FrequencyPenalty = number;
            return this;
        }

        public ICompletionBuilder SetBestOf(int integer)
        {
            if (_request.Stream == true)
            {
                throw new NotSupportedException("Results cannot be streamed.");
            }

            _request.BestOf = integer;
            return this;
        }

        public ICompletionBuilder SetLogitBias(Dictionary<string, int> dictionary)
        {
            _request.LogitBias = dictionary;
            return this;
        }

        public ICompletionBuilder AddLogitBias(string key, int value)
        {
            var dict = _request.LogitBias ??= new Dictionary<string, int>();
            dict.Add(key, value);
            return this;
        }

        public ICompletionBuilder SetUsername(string user)
        {
            _request.User = user;
            return this;
        }

        public ICompletionBuilder SetModel(string modelId)
        {
            _request.Model = modelId;
            return this;
        }

        public ICompletionBuilder SetModel(GptModel model)
        {
            _request.Model = model.Name();
            return this;
        }

        public async Task<IAnswer<ICompletionsMessage>> ExecuteSingleAsync()
        {
            _request.Validate();
            var response = await _webClient.CompletionsAsync(_request);
            return response.ToCompletionsAnswer();
        }

        public async Task<IAnswer<ICompletionsMessage[]>> ExecuteMultipleAsync(int count)
        {
            _request.N = count;

            _request.Validate();
            var response = await _webClient.CompletionsAsync(_request);
            return response.ToCompletionsAnswerCollection();
        }
    }
}
