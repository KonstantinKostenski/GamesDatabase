using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GmeDatabaseInversionOfControl
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<GameDatabaseDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 4;
            })
                .AddEntityFrameworkStores<GameDatabaseDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IBusinessLogicGames, BusinessLogicGames>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ReviewsService>();
            services.AddScoped<IBusinessLogicReviews, BusinessLogicReviews>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IBusinessLogicDevelopers, BusinessLogicDevelopers>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBusinessLogicPublisher, BusinessLogicPublishers>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ICommon, CommonBusinessLogic>();
        }
    }
}
