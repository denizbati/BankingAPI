using Banking.ApiContract.Contract;
using Banking.ApiContract.Response.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Request.Commands
{
    public class CreateAccountCommand: IRequest<ResponseBase<CreateAccountResponse>>
    {
        public Guid Id { get; set; }
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public Price Balance { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}
