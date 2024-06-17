using Microsoft.AspNetCore.Identity;

namespace Application.EntitiesCore
{
    public class ApplicationRole<TKey> : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public ApplicationRole() : base()
        {
        }
    }
}
