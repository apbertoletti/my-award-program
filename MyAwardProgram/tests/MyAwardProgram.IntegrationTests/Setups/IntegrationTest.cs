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

namespace MyAwardProgram.IntegrationTests.Setups
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
                        services.RemoveAll(typeof(AppContextDB));
                        services.AddDbContext<AppContextDB>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetValidJwtAsync());
        }

        private async Task<string> GetValidJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.User.Login, new LoginRequest
            {
                Email = "jose@empresa.com",
                Password = "senha99*"
            });

            var registrationResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return registrationResponse.Token;
        }
    }
}
