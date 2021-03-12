using Application.Interfaces;
using Dapper;
using Domain.AggregatesModel.MemberAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Persistance.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IDbConnection _dbConnection;
        public MemberRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _dbConnection = connectionFactory.GetMemberManagementDatabaseConnection;
        }
        public async Task<IEnumerable<Member>> GetAllWithMinPointAsync(decimal minPoint, string accountStatus)
        {
            var query = $"select m.Id,m.Name,m.Address from public.Members m inner join public.MemberAccounts ma on m.Id=ma.MemberId" +
                $" where ma.Balance>={minPoint} and ma.Status='{accountStatus}'";
            var result = await _dbConnection.QueryAsync<Member>(query);
            if (result == null)
                throw new KeyNotFoundException($"Could not be found.");
            _dbConnection.Dispose();
            return result;
        }
        public async Task<IEnumerable<Member>> GetAll()
        {
            var query = $"select Id,Name,Address from public.Members";
            var result = await _dbConnection.QueryAsync<Member>(query);
            if (result == null)
                throw new KeyNotFoundException($"Could not be found.");
            _dbConnection.Dispose();
            return result;
        }
    }
}
