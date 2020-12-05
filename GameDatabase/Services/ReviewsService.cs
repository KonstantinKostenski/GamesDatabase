using AutoMapper;
using GameDatabase.Data;
using GameDatabase.Interfaces;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class ReviewsService: IReviewsService
    {
        private IBusinessLogicReviews _businessLogicReviews;
        private readonly UserManager<User> _userManager;

        public ReviewsService(IBusinessLogicReviews businessLogicReviews, UserManager<User> userManager)
        {
            _businessLogicReviews = businessLogicReviews;
            _userManager = userManager;
        }

        public Task<User> GetCurrentUserAsync(ClaimsPrincipal claims) => _userManager.GetUserAsync(claims);

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
            await _businessLogicReviews.AddReview(review);
        }

    }
}
