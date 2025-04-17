using Application.Countries.GetByCountryName;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Countries;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("countries/{countryName}", async (
            string countryName,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetCountryByNameQuery(countryName);

            Result<CountryResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Countries);
    }
}
