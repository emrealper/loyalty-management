using Application.Services.Queries.Member.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Services.Queries.Member
{
    public class ListWithMinPointAndAccountStatusQuery : IRequest<MemberListVm>
    {

        public decimal MinPoint { get; set; }
        public string AccountStatus { get; set; }

    }
}
