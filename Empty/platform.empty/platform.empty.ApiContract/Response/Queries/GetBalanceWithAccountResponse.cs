using Banking.ApiContract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Response.Queries
{
    public class GetBalanceWithAccountResponse
    {
        public Guid Id { get; set; }
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public Price Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
