using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationUserLogin<TKey> : IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
