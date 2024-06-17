using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(t => t.VehicleTypeId)
           .IsRequired();

            builder.Property(t => t.Name)
           .HasMaxLength(64);

            builder.Property(t => t.PlateNumber)
           .HasMaxLength(16);
        }
    }
}
