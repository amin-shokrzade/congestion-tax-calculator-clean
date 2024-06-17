using Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identification
{
    public static class IdentificationResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
