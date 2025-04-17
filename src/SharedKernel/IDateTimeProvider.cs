namespace SharedKernel;

public interface IDateTimeProvider
{
#pragma warning disable IDE0040
    public DateTime UtcNow { get; }
#pragma warning restore IDE0040
}
