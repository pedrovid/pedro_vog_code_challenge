using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using VogCodeChallenge.API.Context;
using VogCodeChallenge.API.Models;
using VogCodeChallenge.API.Repositories;
using VogCodeChallenge.API.Services;
using VogCodeChallenge.API.UnitOfWork;
using VogCodeChallenge.API.UnitOfWork.Interfaces;

namespace VogCodeChallenge.API
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
            // In case of using a different database its only necessary to change this service.
            services.AddSqlite();
            services.AddTransient<Repositories.Interfaces.IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<Repositories.Interfaces.IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IUoW, UoW>();
            services.AddSwagger();
            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                FillTestDatabase(app);
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vog Code Challenge V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        /// <summary>
        ///     Function to add some departments and employees to the (in memory) database and test endpoints.
        /// </summary>
        /// <param name="app">
        ///     Application builder to extract DbContext to create test cases.
        /// </param>
        private void FillTestDatabase(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<VogDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            EntityEntry entry = context.Add(new Department()
            {
                Address = "Chihuahua",
                Employees = new List<Employee>() { new Employee { Address = "My Home", FirstName = "Pedro", LastName = "Vidal", JobTitle = "SW Developer" },
                        new Employee { Address = "His Home", FirstName = "Cesar", LastName = "Flores", JobTitle = "Project Manager" } },
                Name = "Development",
            }
            );

            context.SaveChanges();
            entry.State = EntityState.Detached;

            EntityEntry entry2 = context.Add(new Department()
            {
                Address = "Texas",
                Employees = new List<Employee>() { new Employee { Address = "US", FirstName = "John", LastName = "Smith", JobTitle = "Recruiter" }, new Employee { Address = "US", FirstName = "José", LastName = "Perez", JobTitle = "HR Manager" } },
                Name = "HR",
            });

            context.SaveChanges();
            entry2.State = EntityState.Detached;

            EntityEntry entry3 = context.Add(new Department()
            {
                Address = "Canada",
                Employees = null,
                Name = "Marketing",
            });

            context.SaveChanges();
            entry3.State = EntityState.Detached;
        }
    }
}
