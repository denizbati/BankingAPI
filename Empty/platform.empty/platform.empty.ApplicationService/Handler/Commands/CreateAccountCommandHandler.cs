using Banking.ApiContract.Contract;
using Banking.ApiContract.Request.Commands;
using Banking.ApiContract.Response.Commands;
using Banking.ApplicationService.Communicator.Producer;
using Banking.ApplicationService.Communicator.Queue.Models;
using Banking.Domain.Aggregate.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Handler.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ResponseBase<CreateAccountResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountProducer _accountProducer;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IAccountProducer accountProducer)
        {
            _accountRepository = accountRepository;
            _accountProducer = accountProducer;
        }
        public async Task<ResponseBase<CreateAccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var queueRequest = new AccountQueueRequest()
            {
                AccountHolderName = request.AccountHolderName,
                AccountNumber = request.AccountNumber,
                Balance = request.Balance,
                CreatedDate = request.CreatedDate,
                Id = request.Id,

            };

            // burada bütün datalar kuyruğa atılır. Teker teker consume edilir sonrasında. Eventhub kullandım burada fakat eventhubname ve connstring oluşturmadım azureda. Ayrıca 
            //Wrapper oluşturuldu singleinstance queuda configten okunurken. 
            await _accountProducer.SendAccountQueue(queueRequest, cancellationToken);

            //consumer kısmı da yazılmalı .consumerda toplu datalar okunup repositoryde oluşturduğum addrangeli methodu çağırmalı //todo:




            //consumer sonrası return edilmeli throw exception yoksa .
            return new ResponseBase<CreateAccountResponse>()
            {
                Data = new CreateAccountResponse() { Completed = true },
                Success = true
            };
        }


    }
}
