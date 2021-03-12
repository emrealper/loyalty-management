using Domain.Common;
using Domain.Exceptions;
namespace Domain.AggregatesModel.MemberAggregate
{
    public class MemberAccount : BaseAuditableEntity
    {
        public decimal Balance { get; private set; }
        public string Status { get; private set; }
        public string Name { get; private set; }
        protected MemberAccount() { }
        public MemberAccount(decimal balance, string status, string name)
        {
            Balance = balance;
            Status = status;
            Name = name;
        }
        public void CollectPointToAccount(decimal point)
        {
            if (point < 0)
            {
                throw new MemberDomainException("Points cannot be lower than 0");
            }
            Balance += point;
        }
        public void RedeemPointFromAccount(decimal point)
        {
            if (Status == "INACTIVE")
            {
                throw new MemberDomainException("Points cannot be redeemed from inactive account");
            }
            else if (Balance == 0)
            {
                throw new MemberDomainException("Points cannot be redeemed from empty account");
            }
            else if (Balance < point)
            {
                throw new MemberDomainException("Existing balance is not enough to redeem the point");
            }
            Balance -= point;
        }
    }
}
