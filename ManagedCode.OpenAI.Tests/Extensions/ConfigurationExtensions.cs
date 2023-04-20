using Microsoft.Extensions.Configuration;

namespace ManagedCode.OpenAI.Tests.Extensions
{
    public static class ConfigurationExtensions
    {
        public static bool IsUseOpenAIWebClientMock(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>("IsUseOpenAIWebClientMock");
        }

        public static string OpenAIApiKey(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("OpenAIKey");
        }
    }
}
