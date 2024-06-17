using Microsoft.AspNetCore.Identity;


namespace Application.EntitiesCore
{
    public class ApplicationUser<TKey> : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {

        public virtual ICollection<ApplicationUserClaim<Guid>> Claims { get; set; }

    }
}
