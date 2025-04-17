using SharedKernel;

namespace Domain.Countries;

public static class CountryErrors
{
    public static Error NotFound(Guid countryId) => Error.NotFound(
        "Country.NotFound",
        $"The country with the Id = '{countryId}' was not found");

    public static readonly Error NotFoundByName = Error.NotFound(
        "Country.NotFoundByName",
        "The country with the specified name was not found");

    public static readonly Error CountryNameNotUnique = Error.Conflict(
        "Country.CountryNameNotUnique",
        "The provided name is not unique");
}
