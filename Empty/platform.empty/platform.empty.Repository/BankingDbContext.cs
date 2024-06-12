using Banking.Domain.Entities;
using Banking.Repository.Mapper.Point;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Banking.Repository
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountMapper().BaseMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ModifyForAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ModifyForAudit();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
#endif
        }

        private void ModifyForAudit()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
            {
                if (entity is Entity track)
                {
                    track.CreatedDate = DateTime.Now;
                    track.IsActive = true;
                }
            }

            var modified = this.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is Entity track)
                {
                    track.ModifiedDate = DateTime.Now;
                }
            }
        }
    }
}
