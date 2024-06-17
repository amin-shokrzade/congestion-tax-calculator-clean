using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TaxFreeVehicleConfiguration : IEntityTypeConfiguration<TaxFreeVehicle>
    {
        public void Configure(EntityTypeBuilder<TaxFreeVehicle> builder)
        {
            builder.Property(t => t.CityId)
            .IsRequired();

            builder.Property(t => t.VehicleTypeId)
            .IsRequired();
        }
    }
}
