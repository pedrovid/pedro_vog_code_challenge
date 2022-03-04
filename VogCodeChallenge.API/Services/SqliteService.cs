using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.Context;

namespace VogCodeChallenge.API.Services
{
    public static class SqliteService
    {
        public static IServiceCollection AddSqlite(this IServiceCollection services)
        {
            string connectionString = "DataSource=myshareddb;mode=memory;cache=shared";
            SqliteConnection aliveConnection = new SqliteConnection(connectionString);

            aliveConnection.Open();
            services.AddDbContext<VogDbContext>(options => options.UseSqlite(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return services;
        }
    }
}
