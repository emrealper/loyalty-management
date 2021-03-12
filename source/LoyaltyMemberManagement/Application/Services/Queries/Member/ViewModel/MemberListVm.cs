using Application.Services.Queries.Member.Dto;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Queries.Member.ViewModel
{
    public class MemberListVm
    {
        public IList<MemberDto> Members { get; set; }
    }
}
