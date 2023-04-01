using AutoMapper;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.AutoMapperProfiles
{
    public class NoteModelProfile : Profile
    {

        public NoteModelProfile()
        {
            CreateMap<NoteModel, NoteModel>();
        }
    }
}
