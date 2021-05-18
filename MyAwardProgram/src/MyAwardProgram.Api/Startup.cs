using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Data.Repositories;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Movements.Services;
using MyAwardProgram.Domain.Aggregates.Orders.Entities;
using MyAwardProgram.Domain.Aggregates.Partners.Entities;
using MyAwardProgram.Domain.Aggregates.Partners.Enums;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.Domain.Aggregates.Users.Services;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;
using MyAwardProgram.Security;
using MyAwardProgram.Shared.Helpers;
using MyAwardProgram.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

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

            //Console.WriteLine(dbConnectionString);

            services.AddDbContext<AppContextDB>(options =>
                options.UseMySql(dbConnectionString,
                    ServerVersion.AutoDetect(dbConnectionString)));

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Award Program API", Version = "v1" });
            });

            SetupIoC(services);

            var key = Encoding.ASCII.GetBytes(JwtConfiguration.Key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAwardProgramApi"));
            }

            UpdateDatabase(app);
            
            if (env.IsDevelopment())
                SeedDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
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
            var databaseIntegrationTests = "Microsoft.EntityFrameworkCore.InMemory";

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppContextDB>())
                {
                    if (context.Database.ProviderName != databaseIntegrationTests)
                    {
                        context.Database.SetCommandTimeout(commandTimeout);
                        context.Database.Migrate();
                        context.Database.SetCommandTimeout(null);
                    }
                }
            }
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            var databaseIntegrationTests = "Microsoft.EntityFrameworkCore.InMemory";
         
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppContextDB>())
                {
                    using (var transaction = new TransactionScope())
                    {
                        if (context.Database.ProviderName == databaseIntegrationTests)
                            context.Database.EnsureDeleted();

                        context.Database.EnsureCreated();

                        SeedUser(context);
                        SeedAddres(context);
                        SeedPartners(context);
                        SeedProducts(context);
                        SeedOrder(context);
                        SeedOrderProduct(context);
                        SeedMovement(context);

                        transaction.Complete();
                    }
                }
            }
        }

        private static void SeedMovement(AppContextDB context)
        {
            if (!context.Movements.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Id == 1);
                var user2 = context.Users.FirstOrDefault(u => u.Id == 2);
                var user3 = context.Users.FirstOrDefault(u => u.Id == 3);

                var order1 = context.Orders.FirstOrDefault(c => c.Id == 1);
                var order2 = context.Orders.FirstOrDefault(c => c.Id == 2);
                var order3 = context.Orders.FirstOrDefault(c => c.Id == 3);

                var product1 = context.Products.FirstOrDefault(c => c.Id == 1);

                context.Movements.AddRange(new Movement[]
                {
                    new Movement { User = user1, Occurrence = new DateTime(2021, 1, 2), Product = product1, Dots = 40000, DueDate = new DateTime(2021, 3, 2), Type = MovementTypeEnum.Accumulation },
                    new Movement { User = user1, Occurrence = new DateTime(2021, 2, 3), Product = product1, Dots = 45000, DueDate = new DateTime(2021, 4, 3), Type = MovementTypeEnum.Accumulation },
                    new Movement { User = user1, Occurrence = new DateTime(2021, 2, 10), Product = product1, Dots = -76500, DueDate = new DateTime(2021, 4, 3), Type = MovementTypeEnum.Rescue },
                    new Movement { User = user2, Occurrence = new DateTime(2020, 10, 15), Product = product1, Dots = 10000, DueDate = new DateTime(2021, 1, 15), Type = MovementTypeEnum.Accumulation },
                    new Movement { User = user2, Occurrence = new DateTime(2020, 12, 26), Product = product1, Dots = 30000, DueDate = new DateTime(2021, 2, 26), Type = MovementTypeEnum.Accumulation },
                    new Movement { User = user2, Occurrence = new DateTime(2021, 1, 15), Product = null, Dots = -10000, DueDate = null, Type = MovementTypeEnum.Expired },
                    new Movement { User = user2, Occurrence = new DateTime(2020, 1, 30), Product = product1, Dots = 30000, DueDate = new DateTime(2021, 2, 26), Type = MovementTypeEnum.Accumulation },
                });
             
                context.SaveChanges();
            }
        }

        private static void SeedOrderProduct(AppContextDB context)
        {
            if (!context.OrderProducts.Any())
            {
                var order1 = context.Orders.FirstOrDefault(c => c.Id == 1);
                var order2 = context.Orders.FirstOrDefault(c => c.Id == 2);
                var order3 = context.Orders.FirstOrDefault(c => c.Id == 3);

                var product1 = context.Products.FirstOrDefault(c => c.Id == 1);
                var product2 = context.Products.FirstOrDefault(c => c.Id == 2);
                var product3 = context.Products.FirstOrDefault(c => c.Id == 3);
                var product4 = context.Products.FirstOrDefault(c => c.Id == 4);

                var t = context.OrderProducts.Count();

                context.OrderProducts.AddRange(new OrderProduct[]
                {
                    new OrderProduct { OrderId = order1.Id, ProductId = product2.Id, Quantity = 1 },
                    new OrderProduct { OrderId = order1.Id, ProductId = product3.Id, Quantity = 2 },
                    new OrderProduct { OrderId = order1.Id, ProductId = product4.Id, Quantity = 1 },
                    new OrderProduct { OrderId = order2.Id, ProductId = product2.Id, Quantity = 3 },
                });
             
                context.SaveChanges();
            }
        }

        private static void SeedOrder(AppContextDB context)
        {
            if (!context.Orders.Any())
            {
                var user1 = context.Users.Include(u => u.Adresses).FirstOrDefault(c => c.Id == 1);
                var user2 = context.Users.Include(u => u.Adresses).FirstOrDefault(c => c.Id == 2);

                context.Orders.AddRange(new Order[]
                {
                    new Order { Occurrence = new DateTime(2021, 2, 10), User = user1, Address = user1.Adresses.ToList()[0] },
                    new Order { Occurrence = new DateTime(2021, 2, 14), User = user1, Address = user1.Adresses.ToList()[1] },
                    new Order { Occurrence = new DateTime(2021, 3, 4), User = user1, Address = user1.Adresses.ToList()[0] },
                    new Order { Occurrence = new DateTime(2021, 3, 10), User = user2, Address = user2.Adresses.ToList()[0] },
                    new Order { Occurrence = new DateTime(2021, 4, 2), User = user2, Address = user2.Adresses.ToList()[0] },
                });
             
                context.SaveChanges();
            }
        }

        private static void SeedProducts(AppContextDB context)
        {
            if (!context.Products.Any())
            {
                var partner1 = context.Partners.FirstOrDefault(u => u.Id == 1);
                var partner2 = context.Partners.FirstOrDefault(u => u.Id == 2);
                var partner3 = context.Partners.FirstOrDefault(u => u.Id == 2);

                context.Products.Add(new Product { Partner = partner1, SKU = "1324567895", Name = "Acumulo pontos", DotPrice = 1, DotType = ProductDotTypeEnum.Add });
                context.Products.Add(new Product { Partner = partner2, SKU = "78945656465", Name = "Panela de aço", DotPrice = 1500, DotType = ProductDotTypeEnum.Remove });
                context.Products.Add(new Product { Partner = partner2, SKU = "24312412333", Name = "Celular Moto G", DotPrice = 20000, DotType = ProductDotTypeEnum.Remove });
                context.Products.Add(new Product { Partner = partner2, SKU = "24552342432", Name = "Pneu Aro 20", DotPrice = 35000, DotType = ProductDotTypeEnum.Remove });
                context.Products.Add(new Product { Partner = partner3, SKU = "99848822344", Name = "Relogio de parede", DotPrice = 800, DotType = ProductDotTypeEnum.Remove });
                context.Products.Add(new Product { Partner = partner3, SKU = "62235244235", Name = "Roteador Wifi", DotPrice = 7500, DotType = ProductDotTypeEnum.Remove });
            }

            context.SaveChanges();
        }

        private static void SeedPartners(AppContextDB context)
        {
            if (!context.Partners.Any())
            {
                context.Partners.AddRange(new Partner[]
                {
                    new Partner { CNPJ = "12345678901234", Name = "Itau Unibanco" },
                    new Partner { CNPJ = "41512432423555", Name = "Americanas" },
                    new Partner { CNPJ = "99995342344523", Name = "Azul Compania Aérea" },
                });

                context.SaveChanges();
            }
        }

        private static void SeedAddres(AppContextDB context)
        {
            if (!context.Adresses.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Id == 1);
                var user2 = context.Users.FirstOrDefault(u => u.Id == 2);
                var user3 = context.Users.FirstOrDefault(u => u.Id == 3);

                context.Adresses.AddRange(new Address[]
                {
                    new Address { User = user1, Name = "Meu endereço", Description = "Rua das Flores, 20", City = "Rio Claro", State = "SP", Country = "Brasil", ZipCode = "13500452", Type = AddressTypeEnum.Residential }, 
                    new Address { User = user1, Name = "Minha Empresa", Description = "Av. Central, 423", City = "Rio Claro", State = "SP", Country = "Brasil", ZipCode = "13500534", Type = AddressTypeEnum.Commercial },
                    new Address { User = user2, Name = "Em casa", Description = "Rua Trancredo Neves, 3255", City = "Americana", State = "SP", Country = "Brasil", ZipCode = "13453999", Type = AddressTypeEnum.Residential },
                    new Address { User = user2, Name = "Vizinho", Description = "Rua Trancredo Neves, 4002", City = "Americana", State = "SP", Country = "Brasil", ZipCode = "13453998", Type = AddressTypeEnum.Other },
                    new Address { User = user3, Name = "Casa", Description = "Av. Matarazao, 203", City = "Buzios", State = "RJ", Country = "Brasil", ZipCode = "09435244", Type = AddressTypeEnum.Residential }, 
                });
             
                context.SaveChanges();
            }
        }

        private static void SeedUser(AppContextDB context)
        {
            if (!context.Users.Any())
            {
                var crypoHelper = new CryptoHelper();
                context.Users.AddRange(new User[]
                {
                    new User { CPF = "99388926048", Name = "José da Silva", Email = "jose@empresa.com", Password = crypoHelper.GenerateHash("senha99*"), Role = UserRoleEnum.Consumer },
                    new User { CPF = "61991251009", Name = "Carolina Alberta Nunes", Email = "carol@dominio.com", Password = crypoHelper.GenerateHash("88pass*"), Role = UserRoleEnum.Consumer},
                    new User { CPF = "50651670012", Name = "Maria Luiza Cartoz", Email = "malu@itau.com", Password = crypoHelper.GenerateHash("pass55**"), Role = UserRoleEnum.Partner },
                    new User { CPF = "23272283013", Name = "Humberto Gartner", Email = "humberto@dotz.com", Password = crypoHelper.GenerateHash("Hub*dotz"), Role = UserRoleEnum.Admin },
                });

                context.SaveChanges();
            }
        }

        protected virtual void SetupIoC(IServiceCollection services)
        {
            // Domain - Services 
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IMovementService, MovementService>();

            // Infra - Data
            services.AddTransient<AppContextDB>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();

            //Common - Helpers
            services.AddScoped<ICryptoHelper, CryptoHelper>();
        }
    }
}
