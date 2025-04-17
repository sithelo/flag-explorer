namespace Application.Countries.Create;

public sealed record CreateCountryRequest(string CountryName, string FlagName, string City,int Population);
