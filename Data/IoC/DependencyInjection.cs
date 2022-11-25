using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.DataContext.EF;
using SimpleCV.Data.Repositories;
using SimpleCV.Data.Repositories.IRepositories;
using SimpleCV.Data.Utilities;
using SimpleCV.Services;
using SimpleCV.Services.IServices;

namespace SimpleCV.Data.IoC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PgDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("simple_cv_db"))
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                }
            );

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            /// Add Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICVService, CVService>();
            services.AddScoped<ICVGeneratorService, CVGeneratorService>();

            /// Add Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IInfoRepository, InfoRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICVRepository, CVRepository>();
            services.AddScoped<ICVSkillRepository, CVSkillRepository>();
            services.AddScoped<IDescriptionRepository, DescriptionRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
        }
    }
}