using SharedKernel;

namespace Domain.Countries;

public static class FlagErrors
{
    public static readonly Error Empty = Error.Problem("Flag.Empty", "Flag is empty");

    public static readonly Error InvalidLength = Error.Problem(
        "Flag.InvalidLength", "Flag length is invalid");
}
