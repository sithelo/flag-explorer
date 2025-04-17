using System.Net;
using System.Net.Http.Json;
using Api.FunctionalTests.Contracts;
using Api.FunctionalTests.Extensions;
using Api.FunctionalTests.Infrastructure;
using Application.Countries;
using Application.Countries.Create;
using FluentAssertions;

namespace Api.FunctionalTests.Countries;

public class CreateCountryTests : BaseFunctionalTest
{
    public CreateCountryTests(FunctionalTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenFlagNameIsMissing()
    {
        // Arrange
        var request = new CreateCountryRequest("South Africa", "","Pretoria", 60000000);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        CustomProblemDetails problemDetails = await response.GetProblemDetails();

        problemDetails.Errors.Select(e => e.Code)
            .Should()
            .Contain([
                CountryErrorCodes.CreateCountry.MissingFlag
            ]);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenCountryNameIsMissing()
    {
        // Arrange
        var request = new CreateCountryRequest("", "za","Pretoria", 60000000);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        CustomProblemDetails problemDetails = await response.GetProblemDetails();

        problemDetails.Errors.Select(e => e.Code)
            .Should()
            .Contain([CountryErrorCodes.CreateCountry.MissingName]);
    }

  
    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateCountryRequest("South Africa", "za","Pretoria", 60000000);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Should_ReturnConflict_WhenCountryExists()
    {
        // Arrange
        var request = new CreateCountryRequest("South Africa", "za","Pretoria", 60000000);

        // Act
        await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }
}
