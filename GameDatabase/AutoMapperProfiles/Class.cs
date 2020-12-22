using AutoMapper;
using GameDatabase.Data;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.Developer.Name));
            CreateMap<Review, ReviewViewModel>();
        }
    }
}
