using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VogCodeChallenge.API.Context;

namespace VogCodeChallenge.API.Services
{

    // Something like this will be the necessary service to change DB
    public static class MySqlService
    {
        public static IServiceCollection AddMySql(this IServiceCollection services)
        {
            string connectionString = "";
            services.AddDbContext<VogDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }
    }
}
