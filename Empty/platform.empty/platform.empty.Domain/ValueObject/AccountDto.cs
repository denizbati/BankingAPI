using Banking.ApiContract.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.ValueObject
{
    public class AccountDto
    {
        public Guid Id { get; set; }
       
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public Price Balance { get; set; }
    }
}
