using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class VirtualSessionMappingProfile : Profile
    {
        public VirtualSessionMappingProfile()
        {
            CreateMap<VirtualSession, VirtualSessionDto>()
                .ForMember(dest => dest.AthleteId, act => act.MapFrom(src => src.CoachId))
                .ForMember(dest => dest.SportType, act => act.MapFrom(src => src.Type.ToString()));

            CreateMap<VirtualSessionDto, VirtualSession>()
                .ForMember(dest => dest.CoachId, act => act.MapFrom(src => src.TrainerId))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => Enum.IsDefined(typeof(SportType), src.SportType)));

            CreateMap<VirtualSessionDto, VirtualSession>().ReverseMap();
        }
    }
}