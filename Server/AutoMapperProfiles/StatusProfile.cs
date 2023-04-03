using Tasky.Shared.DTOs;
using Tasky.Shared;
using AutoMapper;

namespace Tasky.Server.AutoMapperProfiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {

            CreateMap<Status, StatusDTO>()
                .ForMember(dest => dest.StatusOrder, opt => opt.MapFrom(src => src.StatusOrder))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.StatusName))
                .ForMember(dest => dest.StatusDefinitionOfFinished, opt => opt.MapFrom(src => src.StatusDefinitionOfFinished))
                .ForMember(dest => dest.WorkInProgressLimit, opt => opt.MapFrom(src => src.WorkInProgressLimit));
            CreateMap<StatusDTO, Status>()
                .ForMember(dest => dest.StatusOrder, opt => opt.MapFrom(src => src.StatusOrder));
            CreateMap<Status, Status>();
        }
    }
}
