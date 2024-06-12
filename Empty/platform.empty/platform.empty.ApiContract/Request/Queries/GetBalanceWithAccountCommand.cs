using Banking.ApiContract.Contract;
using Banking.ApiContract.Response.Commands;
using Banking.ApiContract.Response.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Request.Queries
{
    public class GetBalanceWithAccountCommand : IRequest<ResponseBase<GetBalanceWithAccountResponse>>
    {
        public Guid AccountId { get; set; }
    }
}
