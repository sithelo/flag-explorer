using System.Data;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.GetAll;

internal sealed class GetAllCountriesQueryHandler(IDbConnectionFactory factory)
    : IQueryHandler<GetAllQuery, IReadOnlyCollection<CountriesResponse>>
{
    public async Task<Result<IReadOnlyCollection<CountriesResponse>>> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                c.country_name AS Name,
                c.flag_name AS Flag
            FROM countries c
            """;

        using IDbConnection connection = factory.GetOpenConnection();

        List<CountriesResponse> countries = (await connection.QueryAsync<CountriesResponse>(
            sql,
            query)).AsList();

        

        return countries;
    }
}
