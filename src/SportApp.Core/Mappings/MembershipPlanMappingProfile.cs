using AutoMapper;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Mappings
{
    public class MembershipPlanMappingProfile : Profile
    {
        public MembershipPlanMappingProfile()
        {
            CreateMap<MembershipPlan, MembershipPlanDto>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.Type.ToString()));

            CreateMap<MembershipPlanDto, MembershipPlan>()
                .ForMember(dest => dest.Type, act => act.MapFrom(src => Enum.IsDefined(typeof(PlanType), src.Type)));

            CreateMap<MembershipPlanDto, MembershipPlan>().ReverseMap();
        }
    }
}