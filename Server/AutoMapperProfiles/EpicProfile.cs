using AutoMapper;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.AutoMapperProfiles
{
    public class EpicProfile : Profile
    {
        public EpicProfile()
        {
            CreateMap<Epic, Epic>();
           
        }
    }
}
