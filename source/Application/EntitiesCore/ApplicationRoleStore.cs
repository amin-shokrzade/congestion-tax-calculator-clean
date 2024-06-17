using Application.EntitiesCore;
using Application.Interfaces;
using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Infrastructure.Identification
{
    public class ApplicationRoleStore<TRole> : IRoleStore<TRole>
        where TRole : ApplicationRole<Guid>
    {
        IDatabaseContext _context;
        public ApplicationRoleStore(IDatabaseContext context)
        {

            _context = context;
        }
        public async Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError() { Code = $"{ex.HResult}", Description = ex.Message });
            }
        }

        public async Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            try
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError() { Code = $"{ex.HResult}", Description = ex.Message });
            }
        }

        public void Dispose()
        {

        }

        public async Task<TRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return (TRole?)(await _context.Roles.FindAsync(new object[] { Guid.Parse(roleId) }, cancellationToken));
        }

        public async Task<TRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return (TRole?)(await _context.Roles.FindAsync(new object[] { normalizedRoleName }, cancellationToken));
        }

        public async Task<string?> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            return role.NormalizedName;
        }

        public async Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            return role.Id.ToString();
        }

        public async Task<string?> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            return role.Name;
        }

        public async Task SetNormalizedRoleNameAsync(TRole role, string? normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SetRoleNameAsync(TRole role, string? roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return new IdentityResult();
        }
    }
}
