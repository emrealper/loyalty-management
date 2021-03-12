using Application.Services.Queries.Member.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Queries.Member.MappingProfiles
{
   public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<Domain.AggregatesModel.MemberAggregate.Member, MemberDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                  .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}
