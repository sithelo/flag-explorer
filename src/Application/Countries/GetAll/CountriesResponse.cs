namespace Application.Countries.GetAll;

public sealed record CountriesResponse
{
    public string Name { get; init; }
    public string Flag { get; init; }
}
