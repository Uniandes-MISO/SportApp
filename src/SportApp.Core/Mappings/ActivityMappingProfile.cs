using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            CreateMap<Activity, ActivityDto>();

            CreateMap<ActivityDto, Activity>();

            CreateMap<ActivityDto, Activity>().ReverseMap();
        }
    }
}