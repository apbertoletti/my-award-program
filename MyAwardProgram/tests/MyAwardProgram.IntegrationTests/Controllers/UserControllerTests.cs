using FluentAssertions;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.IntegrationTests.Setups;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MyAwardProgram.IntegrationTests.Controllers
{
    public class UserControllerTests : IntegrationTest
    {
        #region Login Tests

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
        public async void Login_WithInvalidCredentials_ReturnNotFoundResponse()
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
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var loginResponse = await response.Content.ReadAsStringAsync();
            loginResponse.Should().BeEmpty();
        }

        #endregion

        #region Create User tests

        [Fact]
        public async void Create_NewUser_ReturnCreatedResponse()
        {
            //Arrange
            var newUser = new NewUserRequest
            {
                CPF = "49779200070",
                Name = "Novo usuário incluido",
                Email = "novo@usuario.com",
                Password = "newPass$11",
                Role = UserRoleEnum.Consumer
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.User.Register, newUser);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var returnedUser = await response.Content.ReadFromJsonAsync<NewUserResponse>();
            returnedUser.Id.Should().BeGreaterThan(0);
            returnedUser.CPF.Should().Be(newUser.CPF);
            returnedUser.Name.Should().Be(newUser.Name);
            returnedUser.Email.Should().Be(newUser.Email);
            returnedUser.Role.Should().Be(newUser.Role);
        }

        #endregion
    }
}
