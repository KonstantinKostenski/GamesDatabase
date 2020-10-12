using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicReviews: IBusinessLogicReviews
    {
        private ReviewRepository _reviewRepository;

        public BusinessLogicReviews(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task AddReview(Review review)
        {
            var currentReview = review; 
            await _reviewRepository.AddAsync(currentReview);
        }

    }
}
