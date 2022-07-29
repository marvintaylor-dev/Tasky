using AutoMapper;
using Tasky.Shared;

namespace Tasky.Server
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<NoteModel, NoteModel>();
            
        }
    }
}
