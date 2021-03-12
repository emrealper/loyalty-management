using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class MemberDomainException : Exception
    {
        public MemberDomainException()
        { }
        public MemberDomainException(string message)
            : base(message)
        { }
        public MemberDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
