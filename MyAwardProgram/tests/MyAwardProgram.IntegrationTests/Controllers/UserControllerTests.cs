using FluentAssertions;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.IntegrationTests.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAwardProgram.IntegrationTests.Controllers
{
    public class UserControllerTests : IntegrationTest
    {
        [Fact]
        public async void Login_WithValidCredentials_ReturnoOkResponse()
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                Email = "jose@empresa.com",
                Password = "senha99*"
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.User.Login, loginRequest);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            loginResponse.UserRole.Should().Be(UserRoleEnum.Consumer);
            loginResponse.Token.Should().NotBeNull();
        }

        [Fact]
        public async void Login_WithInvalidCredentials_ReturnoUnauthorizedResponse()
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                Email = "jose@empresa.com",
                Password = "senha-errada"
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.User.Login, loginRequest);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            var loginResponse = await response.Content.ReadAsStringAsync();
            loginResponse.Should().BeEmpty();
        }
    }
}
