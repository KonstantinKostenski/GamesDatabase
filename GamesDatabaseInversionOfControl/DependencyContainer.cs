using GameDatabase.Data;
using GamesDatabaseBusinessLogic;
using GamesDatabaseBusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GamesDatabaseInversionOfControl
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<GameRepository, GameRepository>();
            services.AddScoped<IBusinessLogicGames, BusinessLogicGames>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBusinessLogicReviews, BusinessLogicReviews>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IBusinessLogicDevelopers, BusinessLogicDevelopers>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBusinessLogicPublisher, BusinessLogicPublishers>();
            services.AddScoped<ICommon, CommonBusinessLogic>();
        }
    }
}
