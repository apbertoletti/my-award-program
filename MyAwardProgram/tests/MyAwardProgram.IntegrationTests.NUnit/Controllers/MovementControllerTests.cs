using MyAwardProgram.IntegrationTests.NUnit.Setups;
using AutoBogus;
using FluentAssertions;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.IntegrationTests.NUnit.Responses.Movements;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyAwardProgram.IntegrationTests.NUnit.Controllers
{
    public class MovementControllerTests : IntegrationTest
    {
        [Test]
        public void Get_Extract_SchemaResponse_Compare()
        {
            //Arrange
            var expectedJsonSchema = JsonSchema.FromSampleJson(JsonSerializer.Serialize(AutoFaker.Generate<ExtractResponse_Expected>())).ToJson();
            var actualJsonSchema = JsonSchema.FromSampleJson(JsonSerializer.Serialize(AutoFaker.Generate<ExtractResponse>())).ToJson();

            //Act

            //Assert
            Assert.AreEqual(expectedJsonSchema, actualJsonSchema);
        }

        [Test]
        public async Task Get_Extract_RoleConsumer_WithoutType_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Consumer);

            var userId = 1;
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 01);

            //Act
            var response = await TestClient.GetAsync($"{ApiRoutes.Movement.GetExtract}?userId={userId}&startDate={startDate.ToString("o")}&endDate={endDate.ToString("o")}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnExtract = await response.Content.ReadFromJsonAsync<List<ExtractResponse>>();
            returnExtract.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.ContainItemsAssignableTo<ExtractResponse>()
                .And.BeInAscendingOrder(c => c.Occurrence);
        }

        [Test]
        public async Task Get_Extract_RoleConsumer_WithTypeAccumulation_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Consumer);

            var userId = 1;
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 01);
            var movementType = MovementTypeEnum.Accumulation;

            //Act
            var response = await TestClient.GetAsync($"{ApiRoutes.Movement.GetExtract}?userId={userId}&startDate={startDate.ToString("o")}&endDate={endDate.ToString("o")}&movementType={movementType}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnExtract = await response.Content.ReadFromJsonAsync<List<ExtractResponse>>();
            returnExtract.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainItemsAssignableTo<ExtractResponse>()
                .And.BeInAscendingOrder(c => c.Occurrence)
                .And.OnlyContain(c => c.Type == MovementTypeEnum.Accumulation);
        }

        [Test]
        public async Task Get_Extract_RoleAdmin_WithTypeExpired_ReturnoOkResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Admin);

            var userId = 2;
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 01);
            var movementType = MovementTypeEnum.Expired;

            //Act
            var response = await TestClient.GetAsync($"{ApiRoutes.Movement.GetExtract}?userId={userId}&startDate={startDate.ToString("o")}&endDate={endDate.ToString("o")}&movementType={movementType}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnExtract = await response.Content.ReadFromJsonAsync<List<ExtractResponse>>();
            returnExtract.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainItemsAssignableTo<ExtractResponse>()
                .And.BeInAscendingOrder(c => c.Occurrence)
                .And.OnlyContain(c => c.Type == MovementTypeEnum.Expired);
        }

        [Test]
        public async Task Get_Extract_RolePartner_ReturnoForbidenResponse()
        {
            //Arrange
            await AuthenticateAsync(UserRoleEnum.Partner);

            var userId = 2;
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 01);
            var movementType = MovementTypeEnum.Expired;

            //Act
            var response = await TestClient.GetAsync($"{ApiRoutes.Movement.GetExtract}?userId={userId}&startDate={startDate}&endDate={endDate}&movementType={movementType}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Test]
        public async Task Get_Extract_WithoutToken_ReturnoUnauthorizedResponse()
        {
            //Arrange            
            var userId = 2;
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 01);
            var movementType = MovementTypeEnum.Expired;

            //Act
            var response = await TestClient.GetAsync($"{ApiRoutes.Movement.GetExtract}?userId={userId}&startDate={startDate}&endDate={endDate}&movementType={movementType}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
