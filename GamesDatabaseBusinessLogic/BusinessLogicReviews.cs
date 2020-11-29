using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicReviews
    {
        private ReviewRepository _reviewRepository;

        public BusinessLogicReviews(ReviewRepository reviewRepository)
        {
            this._reviewRepository = reviewRepository;
        }

        public async void AddReview(Review review)
        {
            await _reviewRepository.AddAsync(review);
        }

    }
}
