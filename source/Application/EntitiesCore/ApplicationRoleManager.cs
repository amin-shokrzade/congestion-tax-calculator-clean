using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.EntitiesCore
{
    public class ApplicationRoleManager<TRole> : RoleManager<TRole>
        where TRole : ApplicationRole<Guid>
    {
        public ApplicationRoleManager(IRoleStore<TRole> store
            , IEnumerable<IRoleValidator<TRole>> roleValidators
            , ILookupNormalizer keyNormalizer
            , IdentityErrorDescriber errors
            , ILogger<ApplicationRoleManager<TRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {

        }
    }
}
