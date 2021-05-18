using FluentAssertions;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.IntegrationTests.Setups;
using System;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MyAwardProgram.IntegrationTests.Controllers
{
    public class MovementControllerTests : IntegrationTest
    {
        [Fact]
        public async void Get_Extract_RoleConsumer_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Consumer);
            var extractRequest = new ExtractRequest
            {
                UserId = 1,
                StartDate = new DateTime(2020, 01, 01),
                EndDate = new DateTime(2021, 12, 01),
                Type = MovementTypeEnum.Accumulation
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Movement.GetExtract, extractRequest);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnExtract = await response.Content.ReadFromJsonAsync<ExtractResponse>();
            returnExtract.ExtractUser.Count.Should().Be(2);
        }

        [Fact]
        public async void Get_Extract_RoleAdmin_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Admin);
            var extractRequest = new ExtractRequest
            {
                UserId = 2,
                StartDate = new DateTime(2020, 01, 01),
                EndDate = new DateTime(2021, 12, 01),
                Type = MovementTypeEnum.Expired
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Movement.GetExtract, extractRequest);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnExtract = await response.Content.ReadFromJsonAsync<ExtractResponse>();
            returnExtract.ExtractUser.Count.Should().Be(1);
        }

        [Fact]
        public async void Get_Extract_RolePartner_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Partner);
            var extractRequest = new ExtractRequest
            {
                UserId = 2,
                StartDate = new DateTime(2020, 01, 01),
                EndDate = new DateTime(2021, 12, 01),
                Type = MovementTypeEnum.Expired
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Movement.GetExtract, extractRequest);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}
