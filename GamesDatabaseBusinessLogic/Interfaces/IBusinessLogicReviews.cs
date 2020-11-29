using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicReviews
    {
        Task AddReview(Review review);
    }
}
