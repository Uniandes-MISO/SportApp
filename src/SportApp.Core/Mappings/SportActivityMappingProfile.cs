using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class SportActivityMappingProfile : Profile
    {
        public SportActivityMappingProfile()
        {
            CreateMap<SportActivity, SportActivityDto>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.Type.ToString()));

            CreateMap<SportActivityDto, SportActivity>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => Enum.IsDefined(typeof(SportType), src.Type)));

            CreateMap<SportActivityDto, SportActivity>().ReverseMap();
        }
    }
}