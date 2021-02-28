using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserApi> GetAll();
        UserApi GetById(int id);
        Task<UserApi> RegisterUserAsync(RegisterViewModel registerUser);
    }
}
