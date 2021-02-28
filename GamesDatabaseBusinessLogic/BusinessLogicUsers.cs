using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicUsers : IBusinessLogicUsers
    {
        IUserApiRepository _userApiRepository;

        public BusinessLogicUsers(IUserApiRepository userApiRepository)
        {
            _userApiRepository = userApiRepository;
        }

        public async System.Threading.Tasks.Task<UserApi> RegisterUserAsync(UserApi user)
        {
            return await _userApiRepository.AddAsync(user);
        }
    }
}
