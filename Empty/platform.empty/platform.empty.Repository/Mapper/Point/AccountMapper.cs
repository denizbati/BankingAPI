
using Banking.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Repository.Mapper.Point
{
    public class AccountMapper : BaseEntityMap<Account>
    {
        protected override void Map(EntityTypeBuilder<Account> eb)
        {
            eb.Property(x => x.Balance).HasColumnType("decimal(18,2)");
            eb.Property(x => x.Id).HasColumnType("uniqueidentifier");
            eb.Property(x => x.AccountNumber).HasColumnType("long");
            eb.Property(x => x.CreatedDate).HasColumnType("datetime");

            eb.ToTable("Account");
        }
    }
}
