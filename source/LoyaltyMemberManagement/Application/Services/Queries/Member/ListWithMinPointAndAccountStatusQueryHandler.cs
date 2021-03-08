using Application.Interfaces;
using Application.Services.Queries.Member.Dto;
using Application.Services.Queries.Member.ViewModel;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries.Member
{
    public class ListWithMinPointAndAccountStatusQueryHandler : IRequestHandler<ListWithMinPointAndAccountStatusQuery, 
        MemberListVm>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ListWithMinPointAndAccountStatusQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        public async Task<MemberListVm> Handle(ListWithMinPointAndAccountStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Members.GetAllWithMinPointAsync(request.MinPoint, request.AccountStatus);

            var memberList = _mapper.Map<List<MemberDto>>(result);

            var vm = new MemberListVm
            {
                Members = memberList

            };
            return vm;
        }
    }
}
