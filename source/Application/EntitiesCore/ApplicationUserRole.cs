using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationUserRole<TKey> : IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
