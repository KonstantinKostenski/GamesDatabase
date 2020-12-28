using AutoMapper;
using GameDatabase.Data;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            CreateMap<GameViewModel, EditGameModel>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId.ToString()));
            CreateMap<CreateGameModel, Game>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => decimal.Parse(src.GenreId)));
            CreateMap < EditGameModel, Game>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => decimal.Parse(src.GenreId)));
            CreateMap<Genre, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));
        }
    }
}
