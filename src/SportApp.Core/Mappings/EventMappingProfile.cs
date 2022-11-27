using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>();

            CreateMap<EventDto, Event>();

            CreateMap<EventDto, Event>().ReverseMap();
        }
    }
}