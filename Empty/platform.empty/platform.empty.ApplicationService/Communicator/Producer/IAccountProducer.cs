using Banking.ApplicationService.Communicator.Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Communicator.Producer
{
    public interface IAccountProducer
    {

        Task SendAccountQueue(AccountQueueRequest request, CancellationToken cancellationToken);
    }
}
