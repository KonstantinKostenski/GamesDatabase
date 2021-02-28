using GameDatabase.Data;
using GameDatabase.Data.Repositories;
using GamesDatabaseBusinessLogic;
using GamesDatabaseBusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GamesDatabaseInversionOfControl
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IBusinessLogicGames, BusinessLogicGames>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBusinessLogicReviews, BusinessLogicReviews>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IBusinessLogicDevelopers, BusinessLogicDevelopers>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBusinessLogicPublisher, BusinessLogicPublishers>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ICommon, CommonBusinessLogic>();
            services.AddScoped<IBusinessLogicUsers, BusinessLogicUsers>();
            services.AddScoped<IUserApiRepository, UserApiRepository>();
        }
    }
}
