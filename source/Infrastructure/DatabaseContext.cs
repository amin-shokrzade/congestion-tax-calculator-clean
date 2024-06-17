using Application.EntitiesCore;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using Infrastructure.Identification;
using System.ComponentModel;
using Infrastructure.Comparers;

namespace Infrastructure
{
    public class DatabaseContext : IdentificationDbContext<ApplicationUser<Guid>, ApplicationRole<Guid>, Guid>, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<City> Cities => Set<City>();
        public DbSet<TaxFreeDate> TaxFreeDates => Set<TaxFreeDate>();
        public DbSet<TaxFreeVehicle> TaxFreeVehicles => Set<TaxFreeVehicle>();
        public DbSet<TimeAndTaxAmount> TimeAndTaxAmounts => Set<TimeAndTaxAmount>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<City>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<TaxFreeDate>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<TaxFreeVehicle>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<TimeAndTaxAmount>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<Vehicle>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<VehicleType>().ToTable(t => t.IsMemoryOptimized());

            builder.Entity<ApplicationUser<Guid>>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();
            });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
                .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter, TimeOnlyComparer>();
        }
    }
}
