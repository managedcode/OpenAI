using ManagedCode.OpenAI.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCode.OpenAI.Client
{
    public class GptClientBuilder : IGptClientBuilder
    {
        private readonly string _apiKey;
        private string? _organization = null;
        private IGptClientConfiguration _configuration = new DefaultGptClientConfiguration();

        public GptClientBuilder(string apiKey)
        {
            _apiKey = apiKey;
        }

        public IGptClientBuilder WithOrganization(string organization)
        {
            _organization = organization;
            return this;
        }

        public IGptClientBuilder Configure(Action<IGptClientConfigurationBuilder> configuration)
        {
            var builder = new GptClientConfigurationBuilder();
            configuration.Invoke(builder);

            _configuration = builder.Build();
            return this;
        }

        public GptClient Build()
        {
            var client = new GptClient(_apiKey, _configuration, _organization);
            return client;
        }
    }
}
