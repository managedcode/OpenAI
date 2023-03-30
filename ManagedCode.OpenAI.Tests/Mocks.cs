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
