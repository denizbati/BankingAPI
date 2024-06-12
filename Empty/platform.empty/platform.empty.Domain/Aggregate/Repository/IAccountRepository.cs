using Banking.Domain.ValueObject;
using Banking.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Aggregate.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetActiveTypeList(Guid account,CancellationToken cancellationToken);
        Task CreateAccount(Account request, CancellationToken cancellationToken);
        Task<AccountDto> GetBalanceWithId(Guid AccountId, CancellationToken cancellationToken);
        Task<bool> CreateDepositMoney(Guid AccountId, CancellationToken cancellationToken);

        Task<bool> CreateWithDraw(Guid AccountId, CancellationToken cancellationToken);

    }
}
