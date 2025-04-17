using Domain.Countries;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public Task<Country?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Countries.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
    public Task<Country?> GetByNameAsync(Name countryName, CancellationToken cancellationToken = default)
    {
        return context.Countries.FirstOrDefaultAsync(u => u.CountryName == countryName, cancellationToken);
    }

    public async Task<bool> IsCountryNameUniqueAsync(Name countryName)
    {
        return !await context.Countries.AnyAsync(u => u.CountryName == countryName);
    }

    public void Insert(Country country)
    {
        context.Countries.Add(country);
    }

}
