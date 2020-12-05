using GameDatabase.Data;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IReviewsService
    {
        Task<User> GetCurrentUserAsync(ClaimsPrincipal claims);

        Task AddReviewAsync(ReviewCreateModel reviewCreateViewModel, int gameId, ClaimsPrincipal claimsPrincipal);
       
    }
}
