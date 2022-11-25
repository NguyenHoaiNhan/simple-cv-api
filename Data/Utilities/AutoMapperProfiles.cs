using AutoMapper;
using SimpleCV.Data.DTO.CV;
using SimpleCV.Data.DTO.CVGenerator;
using SimpleCV.Data.DTO.User;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Models;

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

                CreateMap<CV, CVDTO>().ReverseMap();

                CreateMap<Info, PersonalInfoDTO>()
                    .ForMember(
                        dest => dest.SectionTitle,
                        opt => opt.MapFrom(
                            src => src.InfoTitle
                        )
                    )
                    .ReverseMap();

                CreateMap<Skill, SkillTypeDTO>().ReverseMap();

                CreateMap<Skill, SkillDTO>().ReverseMap();

                CreateMap<Activity, ActivityDTO>().ReverseMap();

                CreateMap<Description, TextForm>().ReverseMap();
            }
        }
    }
}