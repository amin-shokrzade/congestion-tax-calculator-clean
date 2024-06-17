using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace Infrastructure.Configurations
{
    public class TimeAndTaxAmountConfiguration : IEntityTypeConfiguration<TimeAndTaxAmount>
    {
        public void Configure(EntityTypeBuilder<TimeAndTaxAmount> builder)
        {
            builder.Property(t => t.From)
           .HasConversion<TimeOnly>()
           .IsRequired();

            builder.Property(t => t.To)
           .HasConversion<TimeOnly>()
           .IsRequired();

            builder.Property(t => t.Amount)
           .IsRequired();

            builder.Property(t => t.CityId)
           .IsRequired();
        }
    }
}
