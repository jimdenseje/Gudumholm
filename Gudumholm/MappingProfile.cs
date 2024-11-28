using AutoMapper;
using Entities.Models;
using Entities.DTOs;

namespace Gudumholm
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Member, MemberReadDTO>();
            CreateMap<MemberReadDTO, Member>();
        }
    }
}
