using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCode.OpenAI.Client.Abstractions
{
    public interface IGptClientBuilder
    {
        public IGptClientBuilder WithOrganization(string organization);

        public IGptClientBuilder Configure(Action<IGptClientConfigurationBuilder> configuration);

        public GptClient Build();
    }
}
