using SharedKernel;

namespace Domain.Countries;

public sealed class Country : Entity
{
    private Country(Guid id, Name countryName, Flag flagName, Name city, int population)
        : base(id)
    {
        CountryName = countryName;
        FlagName = flagName;
        City = city;
        Population = population;
    }

    private Country()
    {
    }

    public Name CountryName { get; private set; }

    public Flag FlagName { get; private set; }

    public Name City { get; private set; }
    public int Population { get; private set; }

    public static Country Create(Name countryName, Flag flagName, Name city, int population)
    {
        var country = new Country(Guid.NewGuid(), countryName, flagName, city, population);

        country.Raise(new CountryCreatedDomainEvent(country.Id));

        return country;
    }
}
