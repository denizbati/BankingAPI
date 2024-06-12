using Banking.ApiContract.Request;
using Banking.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Banking.Domain.Aggregate
{
    public class Account : Entity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public Price Balance { get; set; }

    }
}
