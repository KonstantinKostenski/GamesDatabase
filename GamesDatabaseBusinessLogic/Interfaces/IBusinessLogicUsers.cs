using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicUsers
    {
        Task<UserApi> RegisterUserAsync(UserApi user);
    }
}
