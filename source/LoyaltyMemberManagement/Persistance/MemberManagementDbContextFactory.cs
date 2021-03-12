using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class MemberManagementDbContextFactory : DesignTimeDbContextFactoryBase<MemberManagementDbContext>
    {
        protected override MemberManagementDbContext CreateNewInstance(DbContextOptions<MemberManagementDbContext> options)
        {
            return new MemberManagementDbContext(options);
        }
    }
}
