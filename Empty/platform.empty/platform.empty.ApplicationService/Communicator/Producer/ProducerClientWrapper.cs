using Azure.Messaging.EventHubs.Producer;
using Banking.Domain.ValueObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Banking.ApplicationService.Communicator.Producer
{

    public class ProducerClientWrapper : IProducerClientWrapper
    {
        private readonly EventHubProducerClient _producerClient;

        public ProducerClientWrapper(IConfiguration configuration)
        {
            var producerServersConfig = (configuration?.GetSection("AccountProducerServer:EventHubConnectionString").ToString());
            _producerClient = new EventHubProducerClient(producerServersConfig, configuration?.GetSection("AccountProducerServer:EventHubName").ToString());
        }


        public EventHubProducerClient GetProducerClient() => _producerClient;
    }
}
