using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class UserTrainingMappingProfile : Profile
    {
        public UserTrainingMappingProfile()
        {
            CreateMap<UserTraining, UserTrainingDto>();

            CreateMap<UserTrainingDto, UserTraining>()
                //.ForMember(dest => dest.Activities, act => act.MapFrom(src => src.Activities))
                ;

            CreateMap<ServiceDto, Service>().ReverseMap();
        }
    }
}