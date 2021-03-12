using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        int? _requestedHashCode;
        private string createdBy;
        private DateTime createdDate;
        private string updatedBy;
        private DateTime? updatedDate;
        private Int64 id;
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        public string CreatedBy { get => createdBy; set => createdBy = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public DateTime? UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public long Id { get => id; set => id = value; }
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseAuditableEntity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            BaseAuditableEntity item = (BaseAuditableEntity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator ==(BaseAuditableEntity left, BaseAuditableEntity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }
        public static bool operator !=(BaseAuditableEntity left, BaseAuditableEntity right)
        {
            return !(left == right);
        }
    }
}
