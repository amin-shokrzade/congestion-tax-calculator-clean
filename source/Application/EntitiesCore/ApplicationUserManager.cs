using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.EntitiesCore
{
    public class ApplicationUserManager<TUser> : UserManager<TUser>, IDisposable
       where TUser : ApplicationUser<Guid>
    {

        public ApplicationUserManager(IUserStore<TUser> store
            , IOptions<IdentityOptions> optionsAccessor
            , IPasswordHasher<TUser> passwordHasher
            , IEnumerable<IUserValidator<TUser>> userValidators
            , IEnumerable<IPasswordValidator<TUser>> passwordValidators
            , ILookupNormalizer keyNormalizer
            , IdentityErrorDescriber errors
            , IServiceProvider services
            , ILogger<ApplicationUserManager<TUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }
    }
}
