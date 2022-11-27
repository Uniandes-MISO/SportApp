using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class RouteMappingProfile : Profile
    {
        public RouteMappingProfile()
        {
            CreateMap<Route, RouteDto>();

            CreateMap<RouteDto, Route>();

            CreateMap<RouteDto, Route>().ReverseMap();
        }
    }
}