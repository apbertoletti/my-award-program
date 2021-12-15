using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyAwardProgram.Api;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace MyAwardProgram.IntegrationTests.XUnit.Setups
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                typeof(DbContextOptions<AppContextDB>));

                        if (descriptor != null)
                            services.Remove(descriptor);

                        services.AddDbContext<AppContextDB>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync(UserRoleEnum userRole)
        {
            var loginRequest = MountLoginRequest(userRole);
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetValidJwtAsync(loginRequest));
        }

        private LoginRequest MountLoginRequest(UserRoleEnum userRole)
        {
            var consumerDefault = new LoginRequest
            {
                Email = "jose@empresa.com",
                Password = "senha99*"
            };

            switch (userRole)
            {
                case UserRoleEnum.Consumer:
                    return consumerDefault;

                case UserRoleEnum.Partner:
                    return new LoginRequest
                    {
                        Email = "malu@itau.com",
                        Password = "pass55**"
                    };

                case UserRoleEnum.Admin:
                    return new LoginRequest
                    {
                        Email = "humberto@dotz.com",
                        Password = "Hub*dotz"
                    };

                default:
                    return consumerDefault;
            }
        }

        private async Task<string> GetValidJwtAsync(LoginRequest loginRequest)
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.User.Login, loginRequest);

            var registrationResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return registrationResponse.Token;
        }
    }
}
