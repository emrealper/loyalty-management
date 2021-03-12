using Domain.Common;
using System.Collections.Generic;
namespace Domain.AggregatesModel.MemberAggregate
{
    public class Member
        : BaseAuditableEntity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        public string Name { get; private set; }
        public string Address { get; private set; }
        // Draft orders have this set to true. Currently we don't check anywhere the draft status of an Order, but we could do it if needed
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so MemberAccount cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method MemberAggrergateRoot.AddMemberAccount() OR MemberAggrergateRoot.AddEmptyMemberAccount() OR  which includes behaviour.
        private readonly List<MemberAccount> _memberAccounts;
        public IReadOnlyCollection<MemberAccount> MemberAccounts => _memberAccounts;
        protected Member()
        {
            _memberAccounts = new List<MemberAccount>();
        }
        public Member(string name, string address) : this()
        {
            Name = name;
            Address = address;
        }
        // DDD Patterns comment
        // This Member AggregateRoot's method "AddMemberAccount()" should be the only way to add Acconts to the Member
        public void AddMemberAccount(decimal balance, string status, string name)
        {
            var account = new MemberAccount(balance, status, name);
            _memberAccounts.Add(account);
        }
        // DDD Patterns comment
        // This Member AggregateRoot's method "AddANewEmptyMemberAccount()" should be the only way to add Acconts to the Member
        public void AddANewEmptyMemberAccount(string name)
        {
            var account = new MemberAccount(0, "ACTIVE", name);
            _memberAccounts.Add(account);
        }
    }
}
