using AutoMapper;
using GameDatabase.Helpers;
using GameDatabase.Interfaces;
using GameDatabase.Models;
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
        public async Task UserServiceShouldLoadUserCorrectlyAsync()
        {
            var mockOptions = new Mock<IOptions<AppSettings>>();
            var mockMapper = new Mock<IMapper>();
            var mockBusinessLogic = new Mock<IBusinessLogicUsers>();

            var mockonfigurationSection = new Mock<IConfigurationSection>();
            mockonfigurationSection.Setup(x => x.GetValue(typeof(string), "APP_SECRET")).Returns("SSUUSSSSUUSSSSUUSSSSUUSS");
            var mockConfiguration = new Mock<IConfiguration>();
            var encodedPassword = _utilityService.EncodePassword("83499999");
            mockBusinessLogic.Setup(member => member.GetUserByNameAndPassword("KonstantinKostenski", encodedPassword))
                .Returns(Task.FromResult(new UserApi() {Username = "KonstantinKostneski", FirstName ="Konstantin", LastName = "Kostenski", Id = 1, Password = encodedPassword }));
            mockConfiguration.Setup(member => member.GetSection("Secret")).Returns(mockonfigurationSection.Object);
            userService = new UserService(mockOptions.Object, mockMapper.Object, mockBusinessLogic.Object, mockConfiguration.Object, _utilityService);
            AuthenticateResponse authenticateResponse = await userService.Authenticate(new AuthenticateRequest() { Username = "KonstantinKostenski", Password = "83499999"});
            Assert.IsTrue(authenticateResponse.FirstName == "Konstantin");
            Assert.IsTrue(authenticateResponse.LastName == "Kostenski");
            Assert.IsTrue(authenticateResponse.Id == 1);
            Assert.IsTrue(authenticateResponse.Token != null);
        }
    }
}