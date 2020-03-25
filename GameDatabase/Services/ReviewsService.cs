using AutoMapper;
using GameDatabase.Data;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class ReviewsService
    {
        private BusinessLogicReviews _businessLogicReviews;
        private readonly UserManager<User> _userManager;

        public ReviewsService(BusinessLogicReviews businessLogicReviews, UserManager<User> userManager)
        {
            this._businessLogicReviews = businessLogicReviews;
            this._userManager = userManager;
        }

        private Task<User> GetCurrentUserAsync(ClaimsPrincipal claims) => _userManager.GetUserAsync(claims);

        public async Task AddReviewAsync(ReviewCreateModel reviewCreateViewModel, int gameId, ClaimsPrincipal claimsPrincipal)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReviewCreateModel, Review>();
            });

            var user = await GetCurrentUserAsync(claimsPrincipal);
            var userId = user?.Id;
            Mapper mapper = new Mapper(configuration);
            var review = mapper.Map<ReviewCreateModel, Review>(reviewCreateViewModel);
            review.GameId = gameId;
            review.AuthorId = userId;
            this._businessLogicReviews.AddReview(review);
        }

    }
}
