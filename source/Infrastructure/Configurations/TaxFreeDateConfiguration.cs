using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace Infrastructure.Configurations
{
    public class TaxFreeDateConfiguration : IEntityTypeConfiguration<TaxFreeDate>
    {
        public void Configure(EntityTypeBuilder<TaxFreeDate> builder)
        {
            builder.Property(t => t.FreeDate)
            .HasConversion<DateOnly>()
            .IsRequired();

            builder.Property(t => t.CityId)
           .IsRequired();
        }
    }
}
