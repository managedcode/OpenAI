using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI;
using Moq;

namespace ManagedCode.OpenAI.Tests
{
    internal static class Mocks
    {
        private const string API_KEY = "#YOUR_GPT_API_KEY#";
        public static IGptClient Client()
        {
            return new GptClient(string.Empty);
        }
    }

}
