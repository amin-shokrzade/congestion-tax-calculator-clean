using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(32);

            builder.Property(t => t.MaxDailyTax)
            .IsRequired();

            builder.Property(t => t.SingleChargeRuleTimeInMinute)
            .IsRequired();

            builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(32);
        }
    }
}
