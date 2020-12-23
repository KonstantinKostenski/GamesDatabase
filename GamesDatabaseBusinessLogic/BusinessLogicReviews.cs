using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicReviews: IBusinessLogicReviews
    {
        private IReviewRepository _reviewRepository;

        public BusinessLogicReviews(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task AddReview(Review review)
        {
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();
        }

    }
}
