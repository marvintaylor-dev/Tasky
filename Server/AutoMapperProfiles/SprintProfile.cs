using AutoMapper;
using Tasky.Shared;

namespace Tasky.Server.AutoMapperProfiles
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintModel, SprintModel>();
        }
    }
}
