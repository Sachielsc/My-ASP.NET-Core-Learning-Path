using AutoMapper;

namespace DemoWebApiProject.AutoMapperProfiles
{
    public class GameProgressProfile : Profile
    {
        public GameProgressProfile()
        {
            CreateMap<Entities.GameProgress, Models.GameProgressDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GameId));
            CreateMap<Models.GameProgressDto, Entities.GameProgress>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
