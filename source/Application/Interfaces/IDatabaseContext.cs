using Application.EntitiesCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<City> Cities { get; }

        DbSet<TaxFreeDate> TaxFreeDates { get; }

        DbSet<TaxFreeVehicle> TaxFreeVehicles { get; }

        DbSet<TimeAndTaxAmount> TimeAndTaxAmounts { get; }

        DbSet<Vehicle> Vehicles { get; }

        DbSet<VehicleType> VehicleTypes { get; }

        DbSet<ApplicationUser<Guid>> Users { get; }

        DbSet<ApplicationUserToken<Guid>> UserTokens { get; }

        DbSet<ApplicationUserRole<Guid>> UserRoles { get; }

        DbSet<ApplicationUserLogin<Guid>> UserLogins { get; }

        DbSet<ApplicationUserClaim<Guid>> UserClaims { get; }
        DbSet<ApplicationRole<Guid>> Roles { get; }

        DbSet<ApplicationRoleClaim<Guid>> RoleClaims { get; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
