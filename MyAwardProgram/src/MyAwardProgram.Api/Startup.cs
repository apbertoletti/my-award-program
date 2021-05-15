using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyAwardProgram.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwardProgram.Api
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
            string dbConnectionString = GetConnectionString();

            Console.WriteLine(dbConnectionString);

            services.AddDbContextPool<AppContextDB>(options =>
                options.UseMySql(dbConnectionString,
                    ServerVersion.AutoDetect(dbConnectionString)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Award Program API", Version = "v1" });
            });
        }

        private string GetConnectionString()
        {
            var host = Configuration["DBHOST"] ?? "localhost";
            var port = Configuration["DBPORT"] ?? "3308";
            var password = Configuration["MYSQL_PASSWORD"] ?? Configuration.GetConnectionString("MYSQL_PASSWORD");
            var userid = Configuration["MYSQL_USER"] ?? Configuration.GetConnectionString("MYSQL_USER");
            var usersDataBase = Configuration["MYSQL_DATABASE"] ?? Configuration.GetConnectionString("MYSQL_DATABASE");

            return $"server={host};port={port};Database={usersDataBase};Uid={userid};Pwd={password};SslMode=none;";
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAwardProgramApi"));
            }

            UpdateDatabase(app);
            SeedDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            var seconds = 60;
            var minutes = 20;
            var commandTimeout = seconds * minutes;

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppContextDB>())
                {
                    context.Database.SetCommandTimeout(commandTimeout);
                    context.Database.Migrate();
                    context.Database.SetCommandTimeout(null);
                }
            }
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppContextDB>())
                {
                    context.Database.EnsureCreated();

                    //SeedPlantRelationship(context);
                    //SeedPlantRelationshipOperationalCut(context);
                    //SeedConfigurationItem(context);

                    context.SaveChanges();
                }
            }
        }
    }
}
