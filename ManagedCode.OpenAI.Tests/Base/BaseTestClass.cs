using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Tests.Extensions;
using ManagedCode.OpenAI.Tests.Services;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests.Base
{
    public class BaseTestClass
    {
        public BaseTestClass(ITestOutputHelper output, IConfiguration configuration)
        {
            Output = output;
            ClientBuilder = new TestGptClientBuilder(configuration.OpenAIApiKey(),
                configuration.IsUseOpenAIWebClientMock());
        }

        public ITestOutputHelper Output { get; }
        internal ITestGptClientBuilder ClientBuilder { get; }
        internal IAzureOpenAiClientBuilder AzureClientBuilder { get; } = new AzureOpenAiClientBuilder();

        protected void Log(string message)
        {
            Output.WriteLine(message);
        }
    }
}
