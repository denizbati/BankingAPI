using Banking.ApiContract.Contract;
using Banking.ApiContract.Request.Commands;
using Banking.ApiContract.Request.Queries;
using Banking.ApiContract.Response.Commands;
using Banking.ApiContract.Response.Queries;
using Banking.Domain.Aggregate.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Handler.Queries
{
    public class GetBalanceWithAccountHandler : IRequestHandler<GetBalanceWithAccountCommand, ResponseBase<GetBalanceWithAccountResponse>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetBalanceWithAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ResponseBase<GetBalanceWithAccountResponse>> Handle(GetBalanceWithAccountCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var response = await _accountRepository.GetBalanceWithId(request.AccountId, cancellationToken);
            
            return new ResponseBase<GetBalanceWithAccountResponse>()
            {

                Data = new GetBalanceWithAccountResponse()
                {
                    AccountHolderName = response.AccountHolderName,
                    Balance = response.Balance,
                    AccountNumber = response.AccountNumber,
                    Id = response.Id,
                }
            };



        }


    }
}
