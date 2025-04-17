using Application.Abstractions.Data;
using Application.Countries.Create;
using Domain.Countries;
using FluentAssertions;
using NSubstitute;
using SharedKernel;

namespace Application.UnitTests.Countries;

public class CreateCountryCommandTests
{
    private static readonly CreateCountryCommand Command = new("Imaginary Country 33", "rr", "EE City", 45);

    private readonly CreateCountryCommandHandler _handler;
    private readonly ICountryRepository _countryRepositoryMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public CreateCountryCommandTests()
    {
        _countryRepositoryMock = Substitute.For<ICountryRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new CreateCountryCommandHandler(
            _countryRepositoryMock,
            _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenFlagIsInvalid()
    {
        // Arrange
        CreateCountryCommand invalidCommand = Command with { FlagName = "invalid_flag" };

        // Act
        Result<string> result = await _handler.Handle(invalidCommand, default);

        // Assert
        result.Error.Should().Be(CountryErrors.CountryNameNotUnique);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenCountryNameIsNotUnique()
    {
        // Arrange
        _countryRepositoryMock.IsCountryNameUniqueAsync(Arg.Is<Name>(e => e.Value == Command.CountryName))
            .Returns(false);

        // Act
        Result<string> result = await _handler.Handle(Command, default);

        // Assert
        result.Error.Should().Be(CountryErrors.CountryNameNotUnique);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenCreateSucceeds()
    {
        // Arrange
        _countryRepositoryMock.IsCountryNameUniqueAsync(Arg.Is<Name>(e => e.Value == Command.CountryName))
            .Returns(true);

        // Act
        Result<string> result = await _handler.Handle(Command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    // [Fact]
    // public async Task Handle_Should_CallRepository_WhenCreateSucceeds()
    // {
    //     // Arrange
    //     _countryRepositoryMock.IsCountryNameUniqueAsync(Arg.Is<Name>(e => e.Value == Command.CountryName))
    //         .Returns(true);
    //
    //     // Act
    //     Result<string> result = await _handler.Handle(Command, default);
    //
    //     // Assert
    //     _countryRepositoryMock.Received(1).Insert(Arg.Is<Country>(u => u.CountryName.Equals(result.Value)));
    // }

    [Fact]
    public async Task Handle_Should_CallUnitOfWork_WhenCreateSucceeds()
    {
        // Arrange
        _countryRepositoryMock.IsCountryNameUniqueAsync(Arg.Is<Name>(e => e.Value == Command.CountryName))
            .Returns(true);

        // Act
        await _handler.Handle(Command, default);

        // Assert
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
