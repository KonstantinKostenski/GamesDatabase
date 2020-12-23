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
        private IMapper _IMapper;
        private readonly UserManager<User> _userManager;

        public ReviewsService(IBusinessLogicReviews businessLogicReviews, UserManager<User> userManager, IMapper mapper)
        {
            _businessLogicReviews = businessLogicReviews;
            _userManager = userManager;
            _IMapper = mapper;
        }

        public Task<User> GetCurrentUserAsync(ClaimsPrincipal claims) => _userManager.GetUserAsync(claims);

        public async Task AddReviewAsync(ReviewCreateModel reviewCreateViewModel, int gameId, ClaimsPrincipal claimsPrincipal)
        {
            var user = await GetCurrentUserAsync(claimsPrincipal);
            var userId = user?.Id;
            var review = _IMapper.Map<ReviewCreateModel, Review>(reviewCreateViewModel);
            review.GameId = gameId;
            review.AuthorId = userId;
            await _businessLogicReviews.AddReview(review);
        }
    }
}
