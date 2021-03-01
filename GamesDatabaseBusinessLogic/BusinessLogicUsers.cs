using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicUsers : IBusinessLogicUsers
    {
        IUserApiRepository _userApiRepository;

        public BusinessLogicUsers(IUserApiRepository userApiRepository)
        {
            _userApiRepository = userApiRepository;
        }

        public async Task<UserApi> GetUserByNameAndPassword(string name, string password)
        {
            return await _userApiRepository.GetUserByNameAndPassword(name, password);
        }

        public async System.Threading.Tasks.Task<UserApi> RegisterUserAsync(UserApi user)
        {
            return await _userApiRepository.AddAsync(user);
        }
    }
}
