using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                options => {
                    options.UseNpgsql(configuration.GetConnectionString("simple-cv-db"));
                }
            );
            
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();
        }
    }
}