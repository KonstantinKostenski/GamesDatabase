using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicReviews
    {
        Task AddReview(Review review);
    }
}
