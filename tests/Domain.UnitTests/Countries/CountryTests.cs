using Domain.Countries;
using FluentAssertions;

namespace Domain.UnitTests.Countries;

public class CountryTests
{
    [Fact]
    public void Create_Should_CreateCountry_WhenFlagIsValid()
    {
        // Arrange
        Flag flagName = Flag.Create("ss").Value;
        var countryName = new Name("Country Name");
        var cityName = new Name("City Name");

        // Act
        var user = Country.Create(countryName, flagName, cityName, 7);

        // Assert
        user.Should().NotBeNull();
    }

   
}
