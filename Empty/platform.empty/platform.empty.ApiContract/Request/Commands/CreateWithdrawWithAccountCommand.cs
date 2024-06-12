using Banking.ApiContract.Contract;
using Banking.ApiContract.Response.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Request.Commands
{
    public class CreateWithdrawWithAccountCommand : IRequest<ResponseBase<CreateWithdrawWithAccountResponse>>
    {
        public Guid AccountId { get; set; }
    }
}
