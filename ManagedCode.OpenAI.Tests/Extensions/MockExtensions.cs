using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Client;
using Moq;

namespace ManagedCode.OpenAI.Tests.Extensions
{
    internal static class MockExtensions
    {
        public static IGptClient Client(this Mock<IOpenAiWebClient> webClient)
        {
            throw new NullReferenceException();
        }
    }
}
