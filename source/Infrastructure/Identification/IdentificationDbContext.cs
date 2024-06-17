using Application.EntitiesCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identification
{
    public class IdentificationDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey, ApplicationUserClaim<TKey>, ApplicationUserRole<TKey>, ApplicationUserLogin<TKey>, ApplicationRoleClaim<TKey>, ApplicationUserToken<TKey>>
    where TUser : ApplicationUser<TKey>
    where TRole : ApplicationRole<TKey>
    where TKey : IEquatable<TKey>
    {
        public IdentificationDbContext(DbContextOptions options) : base(options) { }
        protected IdentificationDbContext() { }

    }
}
