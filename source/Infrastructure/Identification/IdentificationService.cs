using Application.EntitiesCore;
using Application.Interfaces;
using Application.Models;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Identification
{
    public class IdentificationService : IIdentificationService
    {
        private readonly ApplicationUserManager<ApplicationUser<Guid>> _userManager;
        private readonly ApplicationSignInManager<ApplicationUser<Guid>> _signinManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser<Guid>> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _configurationManager;

        public IdentificationService(
            ApplicationUserManager<ApplicationUser<Guid>> userManager,
            ApplicationSignInManager<ApplicationUser<Guid>> signinManager,
            IConfiguration configurationManager,
            IUserClaimsPrincipalFactory<ApplicationUser<Guid>> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _signinManager = signinManager;
            _configurationManager = configurationManager;
        }

        public Guid GetGuestUserId()
        {
            var guestUserId = _configurationManager.GetValue<Guid?>("CongestionTaxCalculatorSecurity:GuestUserId");

            Guard.Against.Null(guestUserId, message: "CongestionTaxCalculatorSecurity:GuestUserId not found in appsettings file.");

            return guestUserId.Value;
        }

        public async Task<string?> GetUserNameAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<string> LoginUser(string email, string password)
        {
            
            return "";
        }

        public string ConvertToHashedPassword(ApplicationUser<Guid> user, string password)
        {
            return _userManager.PasswordHasher.HashPassword(user, password);
        }

        public async Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser<Guid>
            {
                UserName = userName,
                Email = userName,
                PhoneNumber = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<(Result Result, Guid UserId)> CreateUserAsync(Guid Id, string userName, string password, string email, string phoneNumber, bool emailConfirmed = true, bool phoneNumberConfirmed = true, bool lockoutEnabled = true, bool twoFactorEnabled = false)
        {
            var user = new ApplicationUser<Guid>
            {
                Id = Id,
                Email = email,
                EmailConfirmed = emailConfirmed,
                LockoutEnabled = lockoutEnabled,
                PhoneNumber = phoneNumber,
                PhoneNumberConfirmed = phoneNumberConfirmed,
                TwoFactorEnabled = twoFactorEnabled,
                UserName = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<ApplicationUser<Guid>?> FindUserByPhoneNumber(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task<ApplicationUser<Guid>?> FindUserByUsername(string username)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<ApplicationUser<Guid>?> FindUserByEmail(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser<Guid>?> FindUserById(Guid userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<bool> IsInRoleAsync(Guid? userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(Guid? userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<Result> DeleteUserAsync(Guid userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser<Guid> user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
    }
}
