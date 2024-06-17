using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationRoleClaim<TKey> : IdentityRoleClaim<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}