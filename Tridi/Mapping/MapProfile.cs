using AutoMapper;
using Tridi.Data.Dto;
using Tridi.Data.Entities;
using Tridi.Models;

namespace Tridi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
