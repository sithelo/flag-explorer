

namespace Domain.Countries;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Country?> GetByNameAsync(Name countryName, CancellationToken cancellationToken = default);

    Task<bool> IsCountryNameUniqueAsync(Name countryName);

    void Insert(Country country);
}
