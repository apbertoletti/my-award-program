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
    public class AddressControllerTests : IntegrationTest
    {
        #region Register New Aderesses

        [Fact]
        public async void Create_NewUserAddress_WithConsumerRole_ReturnCreatedResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Consumer);

            var newAddress = new NewAddressRequest
            {
                UserId = 1,
                Name = "Endreço da praia",
                Description = "Av. Orla Verde, 103",
                City = "Fernando de Noronha",
                State = "PE",
                Country = "Brasil",
                Type = AddressTypeEnum.Other,
                ZipCode = "53990-000"
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Address.Register, newAddress);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var returnAdress = await response.Content.ReadFromJsonAsync<NewAddressResponse>();
            returnAdress.Id.Should().BeGreaterThan(0);
            returnAdress.UserId.Should().Be(newAddress.UserId);
            returnAdress.Name.Should().Be(newAddress.Name);
            returnAdress.Description.Should().Be(newAddress.Description);
            returnAdress.City.Should().Be(newAddress.City);
            returnAdress.State.Should().Be(newAddress.State);
            returnAdress.Country.Should().Be(newAddress.Country);
            returnAdress.ZipCode.Should().Be(newAddress.ZipCode);
        }

        [Fact]
        public async void Create_NewUserAddress_WithAdminRole_ReturnCreatedResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Admin);

            var newAddress = new NewAddressRequest
            {
                UserId = 1,
                Name = "Endreço da praia",
                Description = "Av. Orla Verde, 103",
                City = "Fernando de Noronha",
                State = "PE",
                Country = "Brasil",
                Type = AddressTypeEnum.Other,
                ZipCode = "53990-000"
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Address.Register, newAddress);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var returnAdress = await response.Content.ReadFromJsonAsync<NewAddressResponse>();
            returnAdress.Id.Should().BeGreaterThan(0);
            returnAdress.UserId.Should().Be(newAddress.UserId);
            returnAdress.Name.Should().Be(newAddress.Name);
            returnAdress.Description.Should().Be(newAddress.Description);
            returnAdress.City.Should().Be(newAddress.City);
            returnAdress.State.Should().Be(newAddress.State);
            returnAdress.Country.Should().Be(newAddress.Country);
            returnAdress.ZipCode.Should().Be(newAddress.ZipCode);
        }

        [Fact]
        public async void Create_NewUserAddress_WithPartnerRole_ReturnForbiden()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Partner);

            var newAddress = new NewAddressRequest
            {
                UserId = 1,
                Name = "Endreço da praia",
                Description = "Av. Orla Verde, 103",
                City = "Fernando de Noronha",
                State = "PE",
                Country = "Brasil",
                Type = AddressTypeEnum.Other,
                ZipCode = "53990-000"
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Address.Register, newAddress);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        #endregion
    }
}
