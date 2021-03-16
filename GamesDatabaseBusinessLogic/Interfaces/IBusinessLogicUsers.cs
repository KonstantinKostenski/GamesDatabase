using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicUsers
    {
        Task<UserApi> RegisterUserAsync(UserApi user);
        Task<UserApi> GetUserByNameAndPassword(string name, string password);
        Task SaveChanges();
    }
}
