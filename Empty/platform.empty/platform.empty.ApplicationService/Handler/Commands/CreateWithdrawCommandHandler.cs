using Banking.ApiContract.Contract;
using Banking.ApiContract.Request.Commands;
using Banking.ApiContract.Response.Commands;
using Banking.Domain.Aggregate.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApplicationService.Handler.Commands
{
    public class CreateWithdrawCommandHandler : IRequestHandler<CreateWithdrawWithAccountCommand, ResponseBase<CreateWithdrawWithAccountResponse>>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateWithdrawCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ResponseBase<CreateWithdrawWithAccountResponse>> Handle(CreateWithdrawWithAccountCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var response = await _accountRepository.CreateWithDraw(request.AccountId, cancellationToken);
            return new ResponseBase<CreateWithdrawWithAccountResponse>()
            {

                Success = response
            };

        }


    }
}
