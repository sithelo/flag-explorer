using Application.Abstractions.Messaging;

namespace Application.Countries.Create;

public sealed record CreateCountryCommand(string CountryName, string FlagName, string City, int Population)
    : ICommand<string>;

