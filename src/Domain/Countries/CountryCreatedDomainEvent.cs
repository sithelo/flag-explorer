using SharedKernel;

namespace Domain.Countries;

public sealed record CountryCreatedDomainEvent(Guid CountryId) : IDomainEvent;
