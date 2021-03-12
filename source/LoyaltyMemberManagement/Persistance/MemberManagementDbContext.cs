using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Common;
using Domain.AggregatesModel.MemberAggregate;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance;
namespace Persistence
{
    public class MemberManagementDbContext : DbContext, IMemberManagementDbContext
    {
        private readonly IDateTime _dateTime;
        public MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> options)
            : base(options)
        {
        }
        public MemberManagementDbContext(
            DbContextOptions<MemberManagementDbContext> options,
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberAccount> MemberAccounts { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "test-user";
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = "test-user";
                        entry.Entity.UpdatedDate = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.TableNamesToLowerCase();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MemberManagementDbContext).Assembly);
        }
    }
}
