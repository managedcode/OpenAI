using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ManagedCode.OpenAI.Tests.Architecture;
using ManagedCode.OpenAI.Tests.Services;

namespace ManagedCode.OpenAI.Tests
{
    public class Startup 
    {
        public void ConfigureServices(IServiceCollection services)
        {
            AddConfiguration(services);
            services.AddScoped<ITestGptClientBuilder, TestGptClientBuilder>();
        }

        private void AddConfiguration(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(Constants.TestSettingsFilePath);
            var configuration = builder.Build();

            services.AddSingleton<IConfiguration>(x => configuration);
        }
    }
}
