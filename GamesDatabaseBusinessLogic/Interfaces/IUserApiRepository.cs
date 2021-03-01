using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IUserApiRepository : IAsyncRepository<UserApi>
    {
        Task<UserApi> GetUserByNameAndPassword(string userName, string password);
    }
}
