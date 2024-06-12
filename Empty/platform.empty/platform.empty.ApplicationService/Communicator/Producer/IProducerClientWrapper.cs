using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Communicator.Producer
{
    public interface IProducerClientWrapper
    {
        EventHubProducerClient GetProducerClient();
    }
}
