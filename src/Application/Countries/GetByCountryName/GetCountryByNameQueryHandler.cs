using System.Data;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.GetByCountryName;

internal sealed class GetCountryByNameQueryHandler(IDbConnectionFactory factory)
    : IQueryHandler<GetCountryByNameQuery, CountryResponse>
{
    public async Task<Result<CountryResponse>> Handle(GetCountryByNameQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                c.id AS Id,
                c.country_name AS Name,
                c.flag_name AS Flag,
                c.city_name AS City,
                c.population AS Population
            FROM countries c
            WHERE c.country_name = @CountryName
            """;
        

        using IDbConnection connection = factory.GetOpenConnection();

        CountryResult? countryResult = await connection.QueryFirstOrDefaultAsync<CountryResult>(
            sql,
            query);

        if (countryResult is null)
        {
            return Result.Failure<CountryResponse>(CountryErrors.NotFoundByName);
        }
        var country = new CountryResponse
        {
            Id = countryResult.Id,
            Name = countryResult.Name,
            Flag = countryResult.Flag,
            CountryDetails = new CountryDetails
            {
                Capital = countryResult.City,
                Population = countryResult.Population,
                Name = countryResult.Name,
            }
        };
        return country;
    }
}
