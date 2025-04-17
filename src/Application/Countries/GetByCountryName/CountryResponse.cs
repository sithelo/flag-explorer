namespace Application.Countries.GetByCountryName;
public class CountryDetails
{
    public string Name { get; init; }
    public int Population { get; init; }
    public string Capital { get; init; }
}

public sealed record CountryResponse
{
   public Guid Id { get; init; }
    
    public string Name { get; init; }
    public string Flag { get; init; }

    public CountryDetails CountryDetails { get; init; }
}

public sealed record CountryResult
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    public string Flag { get; init; }
    public int Population { get; init; }
    public string City { get; init; }
}
