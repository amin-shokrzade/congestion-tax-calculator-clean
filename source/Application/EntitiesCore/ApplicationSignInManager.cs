using Application.EntitiesCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Application.EntitiesCore
{
    public class ApplicationSignInManager<TUser> : SignInManager<TUser>
        where TUser : ApplicationUser<Guid>

    {
        public ApplicationSignInManager(ApplicationUserManager<TUser> userManager
            , IHttpContextAccessor contextAccessor
            , IUserClaimsPrincipalFactory<TUser> claimsFactory
            , IOptions<IdentityOptions> optionsAccessor
            , ILogger<ApplicationSignInManager<TUser>> logger
            , IAuthenticationSchemeProvider schemes
            , IUserConfirmation<TUser> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {

        }
    }
}
