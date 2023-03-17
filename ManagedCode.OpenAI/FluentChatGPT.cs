using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ManagedCode.OpenAI.RequestModels;
using ManagedCode.OpenAI.ResponseModels;

namespace ManagedCode.OpenAI;
internal class FluentChatGPT
{
    private const string _uriCh = @"https://api.openai.com/v1/chat/completions";
    private const string _model = "gpt-3.5-turbo";
    private readonly string _apiKey;
    private double _temperature;
    private double _topP;
    private int _maxTokens;
    private List<RequestMessage> _messages;

    public string Model => _model;
    public double Temperature => _temperature;
    public double TopP => _topP;
    public int MaxTokens => _maxTokens;

    private FluentChatGPT(string apiKey)
    {
        _apiKey = apiKey;
        _temperature = 0.6;
        _topP = 1;
        _maxTokens = 256;
        _messages = new List<RequestMessage>();
    }


    public async Task<ChatCompletion> GetCompletionAsync()
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("authorization", $"Bearer {_apiKey}");


        var request = new Request()
        {
            Model = _model,
            Temperature = _temperature,
            TopP = _topP,
            MaxTokens = _maxTokens,
            Messages = _messages,
        };

        var content = JsonContent.Create(request,
            new MediaTypeHeaderValue("application/json"));

        var response = await client.PostAsync(_uriCh, content);

        if(!response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            throw new Exception(responseString);
        }
        else
        {
            var responseCompletion = await response.Content
                .ReadFromJsonAsync<ChatCompletion>(
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return responseCompletion;
        }
    }

    public ConversationBuilder NewConversation()
    {
        _messages.Clear();
        return new ConversationBuilder(_messages);
    }

    public ConversationBuilder ContinueConversation() => new ConversationBuilder(_messages);

    public static FluentChatGPTBuilder ChatBuilder(string apiKey)
        => new FluentChatGPTBuilder(apiKey);

    public class FluentChatGPTBuilder
    {
        private readonly FluentChatGPT _fluentChatGPT;

        public FluentChatGPTBuilder(string apiKey)
        {
            _fluentChatGPT = new FluentChatGPT(apiKey);
        }

        public FluentChatGPTBuilder WithTemperature(double temperature)
        {
            _fluentChatGPT._temperature = temperature;
            return this;
        }

        public FluentChatGPTBuilder WithTopP(double topP)
        {
            _fluentChatGPT._topP = topP;
            return this;
        }

        public FluentChatGPTBuilder WithMaxTokens(int maxTokens)
        {
            _fluentChatGPT._maxTokens = maxTokens;
            return this;
        }

        public FluentChatGPT Build()
        {
            return _fluentChatGPT;
        }
    }

    public class ConversationBuilder
    {
        private List<RequestMessage> _messages;
        public ConversationBuilder(List<RequestMessage> messages)
        {
            _messages = messages;
        }

        public ConversationBuilder AsSystem(string behavior)
        {
            _messages.Add(new RequestMessage()
            {
                Role = "system",
                Content = behavior
            });

            return this;
        }

        public ConversationBuilder AsAssistant(string example)
        {
            _messages.Add(new RequestMessage()
            {
                Role = "assistant",
                Content = example
            });

            return this;
        }

        public ConversationBuilder AsUser(string instruction)
        {
            _messages.Add(new RequestMessage()
            {
                Role = "user",
                Content = instruction
            });

            return this;
        }
    }
}
