using ManagedCode.OpenAI.Tests.Extensions;
using Microsoft.Extensions.Configuration;

namespace ManagedCode.OpenAI.Tests.Architecture
{
    internal class IntegrationTestsRuntime
    {
        private static IntegrationTestsRuntime? _default;

        private IntegrationTestsRuntime()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(Constants.TestSettingsFilePath);
            var configuration = builder.Build();
            IsManualTestsEnabled = !string.IsNullOrWhiteSpace(configuration.OpenAIApiKey());
        }

        public static IntegrationTestsRuntime Default => _default
            ??= new IntegrationTestsRuntime();

        public bool IsManualTestsEnabled { get; }
    }
}
