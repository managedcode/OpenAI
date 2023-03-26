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
