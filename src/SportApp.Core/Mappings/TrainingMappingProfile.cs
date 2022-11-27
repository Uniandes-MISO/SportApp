using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class TrainingMappingProfile : Profile
    {
        public TrainingMappingProfile()
        {
            CreateMap<Training, TrainingDto>()
                .ForMember(dest => dest.Activities, act => act.MapFrom(src => src.Activities))
                ;

            CreateMap<TrainingDto, Training>()
                //.ForMember(dest => dest.Activities, act => act.MapFrom(src => src.Activities))
                ;

            CreateMap<ServiceDto, Service>().ReverseMap();
        }
    }
}