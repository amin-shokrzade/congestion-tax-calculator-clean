using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationUserClaim<TKey> : IdentityUserClaim<TKey>
         where TKey : IEquatable<TKey>
    {

    }
}
