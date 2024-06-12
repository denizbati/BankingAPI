using Banking.ApiContract.Request;
using Banking.Domain.Aggregate;
using Banking.Domain.Aggregate.Repository;
using Banking.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Banking.Repository.Repositories
{
    internal class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context)
        {
        }

        public async Task<Account> GetActiveTypeList(Guid account,CancellationToken cancellationToken)
        {
            return await _entities.Where(x => x.IsActive && x.Id==account ).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task CreateAccount(Account request,CancellationToken cancellationToken)
        {
          await _entities.AddRangeAsync(request);
        }
        
        public async Task<AccountDto> GetBalanceWithId(Guid AccountId, CancellationToken cancellationToken)
        {
       //yeni bir dto oluşturulup balanceı sadece selectorde alabilirsin. Ama çok sıcak ben devam edemicem.
                return await _entities.Where(x => x.IsActive && x.Id == AccountId).Select(s => new AccountDto
                {
                    Id = s.Id,
                    Balance = s.Balance,
                    AccountNumber = s.AccountNumber,
                    AccountHolderName = s.AccountHolderName,
                }).FirstOrDefaultAsync(cancellationToken);
           
           
        }

        //içerideki balance kadar kendi ekliyor. Requestte amount verilmediği için requestte bu şekilde tamamladım 
        public async Task<bool> CreateDepositMoney(Guid AccountId, CancellationToken cancellationToken)
        {

            try
            {
                var dataList= await GetActiveTypeList(AccountId, cancellationToken);
             
                if (dataList != null)
                {
                    dataList.Balance += dataList.Balance;
                }
               _entities.Update(dataList);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        // balance ı çekip sıfırlıyor
        public async Task<bool> CreateWithDraw(Guid AccountId, CancellationToken cancellationToken)
        {

            try
            {
                var dataList = await GetActiveTypeList(AccountId, cancellationToken);

                if (dataList != null)
                {
                    dataList.Balance = new Price(0);
                }
                _entities.Update(dataList);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

    }
}
