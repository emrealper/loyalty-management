using Domain.AggregatesModel.MemberAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Interfaces
{
    public interface IMemberManagementDbContext
    {
        DbSet<Member> Members { get; set; }
        DbSet<MemberAccount> MemberAccounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
