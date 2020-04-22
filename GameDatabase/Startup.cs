using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameDatabase.Data;
using GameDatabase.Services;
using GamesDatabaseBusinessLogic;
using GamesDatabaseBusinessLogic.Interfaces;
using GameDatabase.Interfaces;

namespace GameDatabase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
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
            services.AddScoped<IBusinessLogicGames, BusinessLogicGames>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<ReviewsService>();
            services.AddScoped<BusinessLogicReviews>();
            services.AddScoped<ReviewRepository>();
            services.AddScoped<CommonService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IBusinessLogicDevelopers, BusinessLogicDevelopers>();
            services.AddScoped<DeveloperRepository>();
            services.AddScoped<PublisherRepository>();
            services.AddScoped<BusinessLogicPublishers>();
            services.AddScoped<CommonBusinessLogic>();
            services.AddScoped<GameRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
