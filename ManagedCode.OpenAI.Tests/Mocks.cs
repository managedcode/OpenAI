using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Tests
{
    internal static class Mocks
    {
        private const string API_KEY = "#YOUR_GPT_API_KEY#";

        public static IGptClient Client()
        {
            return new GptClient(API_KEY);
        }
    }
}
