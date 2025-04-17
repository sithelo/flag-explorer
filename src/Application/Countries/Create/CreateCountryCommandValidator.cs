using FluentValidation;

namespace Application.Countries.Create;

internal sealed class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.CountryName)
            .NotEmpty().WithErrorCode(CountryErrorCodes.CreateCountry.MissingName);

        RuleFor(c => c.FlagName)
            .NotEmpty().WithErrorCode(CountryErrorCodes.CreateCountry.MissingFlag);
    }
}
