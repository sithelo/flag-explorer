using Application.Countries.Create;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Countries;

public class Post : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("countries", async (
            CreateCountryRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateCountryCommand(
                request.CountryName,
                request.FlagName,
                request.City,
                request.Population);

            Result<string> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Countries);
    }
}
