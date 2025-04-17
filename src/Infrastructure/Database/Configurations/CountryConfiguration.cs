using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");

        builder.ComplexProperty(
            u => u.CountryName,
            b => b.Property(e => e.Value).HasColumnName("country_name"));
          

        builder.ComplexProperty(
            u => u.FlagName,
            b => b.Property(e => e.Value).HasColumnName("flag_name"));

        builder.ComplexProperty(
            u => u.City,
            b => b.Property(e => e.Value).HasColumnName("city_name"));

        builder.Property(u => u.Population)
            .HasColumnName("population")
            .HasColumnType("int");

       
    }
}
