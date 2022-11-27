using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.SportType, act => act.MapFrom(src => src.SportType.ToString()));

            CreateMap<ServiceDto, Service>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => Enum.IsDefined(typeof(ServiceType), src.Type)))
                .ForMember(dest => dest.SportType, act => act.MapFrom(src => Enum.IsDefined(typeof(SportType), src.SportType)));

            CreateMap<ServiceDto, Service>().ReverseMap();
        }
    }
}