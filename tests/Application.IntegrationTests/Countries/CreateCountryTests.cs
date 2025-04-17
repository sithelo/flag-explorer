// using Application.IntegrationTests.Infrastructure;
// using Application.Countries.Create;
// using Domain.Countries;
// using FluentAssertions;
// using SharedKernel;
//
// namespace Application.IntegrationTests.Countries;
//
// public class CreateCountryTests : BaseIntegrationTest
// {
//     public CreateCountryTests(IntegrationTestWebAppFactory factory)
//         : base(factory)
//     {
//     }
//
//     [Fact]
//     public async Task Handle_Should_CreateCountry_WhenCommandIsValid()
//     {
//         // Arrange
//         var command = new CreateCountryCommand("Imaginary Country 2", "qq", "IM City", 40);
//
//         // Act
//         Result<string> result = await Sender.Send(command);
//
//         // Assert
//         result.IsSuccess.Should().BeTrue();
//     }
//
//     [Fact]
//     public async Task Handle_Should_AddCountryToDatabase_WhenCommandIsValid()
//     {
//         // Arrange
//         var command = new CreateCountryCommand("Imaginary Country", "im", "IM City", 40);
//
//         // Act
//         Result<string> result = await Sender.Send(command);
//
//         // Assert
//         Country? country = await DbContext.Countries.FindAsync(result.Value);
//
//         country.Should().NotBeNull();
//     }
// }
