using AutoMapper;
using SimpleCV.Data.DTO;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.Utilities
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<User, UserToAddDTO>().ReverseMap();
            }
        }
    }
}