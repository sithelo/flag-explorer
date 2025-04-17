using SharedKernel;

namespace Domain.Countries;

public sealed record Flag
{
    private Flag(string value) => Value = value;

    public string Value { get; }

    public static Result<Flag> Create(string? flag)
    {
        if (string.IsNullOrEmpty(flag))
        {
            return Result.Failure<Flag>(FlagErrors.Empty);
        }

        if (flag.Length != 2)
        {
            return Result.Failure<Flag>(FlagErrors.InvalidLength);
        }
        

        return new Flag(flag);
    }
}
