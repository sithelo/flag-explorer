using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.Create;

internal sealed class CreateCountryCommandHandler(
    ICountryRepository countryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCountryCommand, string>
{
    public async Task<Result<string>> Handle(
        CreateCountryCommand command,
        CancellationToken cancellationToken)
    {
        var countryName = new Name(command.CountryName);
        if (!await countryRepository.IsCountryNameUniqueAsync(countryName))
        {
            return Result.Failure<string>(CountryErrors.CountryNameNotUnique);
        }
        Result<Flag> flagNameResult = Flag.Create(command.FlagName);
        if (flagNameResult.IsFailure)
        {
            return Result.Failure<string>(flagNameResult.Error);
        }
        Flag flagName = flagNameResult.Value;


        var city = new Name(command.City);
        var country = Country.Create(countryName, flagName, city, command.Population);

        countryRepository.Insert(country);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return country.CountryName.Value;
    }
}
