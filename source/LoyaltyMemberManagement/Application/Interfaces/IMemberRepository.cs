
using Domain.AggregatesModel.MemberAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {

        Task<IEnumerable<Member>> GetAllWithMinPointAsync(decimal minPoint,string accountStatus);
        Task<IEnumerable<Member>> GetAll();
    }
}
