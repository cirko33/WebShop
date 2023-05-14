using AutoMapper;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Config
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, ProfileDTO>().ReverseMap();
            CreateMap<User, EditProfileDTO>().ReverseMap();
        }
    }
}
