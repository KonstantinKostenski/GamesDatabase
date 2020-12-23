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
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Publisher.Id))
                .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.Developer.Name))
                .ForMember(dest => dest.DeveloperId, opt => opt.MapFrom(src => src.Developer.Id));
            CreateMap<Review, ReviewViewModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
            CreateMap<ReviewCreateModel, Review>();
        }
    }
}
