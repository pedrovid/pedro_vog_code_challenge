using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace VogCodeChallenge.API.Services
{
    public static class SwaggerService
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = "Vog Code Challenge",
                    Version = groupName,
                    Description = "Backend Challenge",
                    Contact = new OpenApiContact
                    {
                        Name = "Xlabs",
                        Email = string.Empty,
                        Url = new Uri("https://xlabs.mx/"),
                    }
                });
            });

            return services;
        }
    }
}
