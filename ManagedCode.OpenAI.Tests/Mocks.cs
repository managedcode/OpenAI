using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Tests
{
    internal static class Mocks
    {
        private const string API_KEY = "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";

        public static IGptClient Client()
        {
            return new GptClient(API_KEY);
        }
    }
}
