using AutoMapper;

namespace DemoWebApiProject.AutoMapperProfiles
{
    public class GameProgressOnPlatformProfile : Profile
    {
        public GameProgressOnPlatformProfile() {
            CreateMap<Entities.GameProgressOnPlatform, Models.GameProgressOnPlatformDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GameProgressOnThisPlatformId));
        }
    }
}
