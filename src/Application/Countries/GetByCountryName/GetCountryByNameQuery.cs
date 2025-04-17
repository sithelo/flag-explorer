using Application.Abstractions.Messaging;

namespace Application.Countries.GetByCountryName;

public sealed record GetCountryByNameQuery(string CountryName) : IQuery<CountryResponse>;
