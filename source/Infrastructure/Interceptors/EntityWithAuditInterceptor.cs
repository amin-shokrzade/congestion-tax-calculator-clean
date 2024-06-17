using Application.Interfaces;
using Application.Security;
using Domain.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interceptors
{
    public class EntityWithAuditInterceptor : SaveChangesInterceptor
    {
        private readonly IUser _user;
        private readonly TimeProvider _dateTime;

        public EntityWithAuditInterceptor(
            IUser user,
            TimeProvider dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseEntityWithAudit>())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.Id == Guid.Empty)
                    {
                        entry.Entity.Id = KeyGenerator.GenerateGuid();
                    }

                    entry.Entity.Creator = _user.Id;
                    entry.Entity.CreatedOn = _dateTime.GetUtcNow();
                    entry.Entity.Deleted = false;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.Modifier = _user.Id;
                    entry.Entity.ModifiedOn = _dateTime.GetUtcNow();
                }
            }
        }
    }

    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
