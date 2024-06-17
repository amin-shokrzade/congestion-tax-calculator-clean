using Application.EntitiesCore;
using Application.Models;

namespace Application.Interfaces
{
    public interface IIdentificationService
    {
        Task<string?> GetUserNameAsync(Guid userId);

        Task<bool> IsInRoleAsync(Guid? userId, string role);

        Task<bool> AuthorizeAsync(Guid? userId, string policyName);

        Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(Guid userId);

        public Task<string> LoginUser(string email, string password);

        public Guid GetGuestUserId();

        string ConvertToHashedPassword(ApplicationUser<Guid> user, string password);

        Task<(Result Result, Guid UserId)> CreateUserAsync(Guid Id, string userName, string password, string email, string phoneNumber, bool emailConfirmed = true, bool phoneNumberConfirmed = true, bool lockoutEnabled = true, bool twoFactorEnabled = false);

        Task<ApplicationUser<Guid>?> FindUserByPhoneNumber(string phoneNumber);

        Task<ApplicationUser<Guid>?> FindUserByUsername(string username);

        Task<ApplicationUser<Guid>?> FindUserByEmail(string email);

        Task<ApplicationUser<Guid>?> FindUserById(Guid userId);

    }
}
