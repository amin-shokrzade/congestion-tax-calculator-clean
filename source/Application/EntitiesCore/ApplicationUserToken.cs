using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationUserToken<TKey> : IdentityUserToken<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
