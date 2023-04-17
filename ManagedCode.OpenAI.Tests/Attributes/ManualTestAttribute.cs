using ManagedCode.OpenAI.Tests.Architecture;
using Xunit;

namespace ManagedCode.OpenAI.Tests.Attributes
{
    public class ManualTestAttribute : FactAttribute
    {
        public ManualTestAttribute()
        {
            if (!IntegrationTestsRuntime.Default.IsManualTestsEnabled)
            {
                Skip = "Test Disabled";
            }
        }
    }
}
