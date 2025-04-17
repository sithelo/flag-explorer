using Application.Abstractions.Messaging;

namespace Application.Countries.GetAll;

public sealed record GetAllQuery : IQuery<IReadOnlyCollection<CountriesResponse>>;
  