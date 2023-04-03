using Tasky.Shared.DTOs;
using Tasky.Shared;
using AutoMapper;

namespace Tasky.Server.AutoMapperProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        {
            CreateMap<Member, MemberDTO>();
            CreateMap<MemberDTO, Member>();
            CreateMap<Member, Member>();
        }
    }
}
