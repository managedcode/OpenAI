using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;
using Moq;

namespace ManagedCode.OpenAI.Tests.Services
{
    internal interface ITestGptClientBuilder : IGptClientBuilder
    {
        public ITestGptClientBuilder ConfigureMockWebClient(Action<Mock<IOpenAiWebClient>> mock);
    }

    internal class TestGptClientBuilder : GptClientBuilder, ITestGptClientBuilder
    {
        private Action<Mock<IOpenAiWebClient>>? _mockConfiguration;

        public TestGptClientBuilder(string apiKey, bool useWebMockClient) : base(apiKey)
        {
            IsUseWebMockClient = useWebMockClient;
        }

        protected bool IsUseWebMockClient { get; }

        public ITestGptClientBuilder ConfigureMockWebClient(Action<Mock<IOpenAiWebClient>> mock)
        {
            _mockConfiguration = mock;
            return this;
        }

        public override GptClient Build()
        {
            if (IsUseWebMockClient && _mockConfiguration != null)
            {
                var mock = new Mock<IOpenAiWebClient>();
                _mockConfiguration.Invoke(mock);
                return new GptClient(Configuration, mock.Object);
            }

            return base.Build();
        }
    }
}
