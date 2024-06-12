using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Banking.ApplicationService.Communicator.Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Communicator.Producer
{
       public class AccountProducer : IAccountProducer
    {
        private readonly EventHubProducerClient _producerServerClient;

        public AccountProducer( IProducerClientWrapper producerClientWrapper)
        {

            _producerServerClient = producerClientWrapper.GetProducerClient();
        }
        public async Task SendAccountQueue(AccountQueueRequest request, CancellationToken cancellationToken)
        {

          var data = new EventData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request)));

            List<EventData> eventDatas = new() { data };

            try
            {
                await _producerServerClient.SendAsync(eventDatas, cancellationToken);

            }
            catch (Exception ex)
            {


            }



        }
    }
}
