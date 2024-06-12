using Banking.ApiContract.Contract;
using Banking.ApiContract.Request.Commands;
using Banking.ApiContract.Response.Commands;
using Banking.ApiContract.Response.Queries;
using Banking.Domain.Aggregate.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Handler.Commands
{
    public class CreateDepositMoneyCommandHandler : IRequestHandler<CreateDepositMoneyCommand, ResponseBase<CreateDepositMoneyResponse>>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateDepositMoneyCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ResponseBase<CreateDepositMoneyResponse>> Handle(CreateDepositMoneyCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var response = await _accountRepository.CreateDepositMoney(request.AccountId,cancellationToken);
            return new ResponseBase<CreateDepositMoneyResponse>()
            {

               Success=response
            };


        }


    }
}
