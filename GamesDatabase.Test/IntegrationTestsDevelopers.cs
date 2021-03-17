using GameDatabase.APIControllers;
using GameDatabase.Data;
using GameDatabase.Services;
using GamesDatabaseBusinessLogic;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GamesDatabase.Test
{
    public class IntegrationTestsDevelopers
    {
        DevelopersController developersController;

        public IntegrationTestsDevelopers()
        {
            var options = new DbContextOptionsBuilder<GameDatabaseDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
                .EnableSensitiveDataLogging()
                .Options;
            developersController = new DevelopersController(new GameDatabaseDbContext(options: options), new DeveloperService(new BusinessLogicDevelopers(new DeveloperRepository(new GameDatabaseDbContext(options: options)))));
        }

        [Test]
        public async Task TestInsert()
        {
            var developer = new Developer();
            developer.Description = "TestDescription";
            developer.Location = "TestDescription";
            developer.LogoUrl = "TestDescription";
            developer.Name = "TestDescription";
            CreatedAtActionResult result = (CreatedAtActionResult)await developersController.PostDeveloper(developer);
            Assert.That(result.StatusCode == 201);
        }

        [Test]
        public async Task TestDelete()
        {
            var developer = new Developer();
            developer.Description = "TestDescription";
            developer.Location = "TestDescription";
            developer.LogoUrl = "TestDescription";
            developer.Name = "TestDescription";
            await developersController.PostDeveloper(developer);
            OkObjectResult resultDelete = (OkObjectResult)await developersController.DeleteDeveloper(developer.Id);
            Assert.That(resultDelete.StatusCode == 200);
        }

        [Test]
        public async Task TestUpdate()
        {
            var result = (OkObjectResult)(await developersController.GetDeveloper(4));
            var developer = (Developer)result.Value;
            OkObjectResult resultUpdate = (OkObjectResult)await developersController.PutDeveloper(developer.Id, developer);
            Assert.That(resultUpdate.StatusCode == 200);
        }
    }
}
