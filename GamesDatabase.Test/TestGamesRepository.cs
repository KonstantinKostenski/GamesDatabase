using AutoMapper;
using GameDatabase.Helpers;
using GameDatabase.Interfaces;
using GameDatabase.Services;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
//using GamesDatabaseBusinessLogic.Interfaces;

namespace GamesDatabase.Test
{
    public class Tests
    {
        IUserService userService;
        IUtilityService _utilityService;

        public Tests()
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _utilityService = new UtilityService();
        }

        //integration tests
        [Test]
        public void UserServiceShouldLoadUserCorrectly()
        {
            var mockOptions = new Mock<IOptions<AppSettings>>();
            var mockMapper = new Mock<IMapper>();
            var mockBusinessLogic = new Mock<IBusinessLogicUsers>();
            var mockConfiguration = new Mock<IConfiguration>();
            var encodedPassword = _utilityService.EncodePassword("83499999");
            mockBusinessLogic.Setup(member => member.GetUserByNameAndPassword("KonstantinKostneski", encodedPassword)).Returns(Task.FromResult(new UserApi() {Username = "KonstantinKostneski", FirstName ="Konstantin", LastName = "Kostenski", Id = 1, Password = encodedPassword }));
            userService = new UserService(mockOptions.Object, mockMapper.Object, mockBusinessLogic.Object, mockConfiguration.Object, _utilityService);
            Assert.Pass();
        }
    }
}