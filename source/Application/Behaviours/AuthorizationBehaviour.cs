using Application.Exceptions;
using Application.Interfaces;
using Application.Security;
using MediatR;
using System.Diagnostics;
using System.Reflection;

namespace Application.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUser _user;
        private readonly IIdentificationService _identityService;

        public AuthorizationBehaviour(
            IUser user,
            IIdentificationService identityService)
        {
            _user = user;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            var authorizeAttributes = new List<AuthorizeAttribute>();

            var stackFrame = new StackTrace().GetFrames()?.FirstOrDefault(x => x.GetMethod()?.DeclaringType?.BaseType?.Name == "EndpointGroupBase");

            if (stackFrame != null)
            {
                authorizeAttributes = stackFrame.GetMethod()?.DeclaringType?.GetCustomAttributes<AuthorizeAttribute>().ToList();
            }

            if (authorizeAttributes != null && authorizeAttributes.Any())
            {
                // Must be authenticated user
                if (_user.Id == _identityService.GetGuestUserId())
                {
                    throw new UnauthorizedAccessException();
                }

                // Role-based authorization
                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        foreach (var role in roles)
                        {
                            var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }
                    }

                    // Must be a member of at least one role in roles
                    if (!authorized)
                    {
                        throw new InvalidAccessException();
                    }
                }

                // Policy-based authorization
                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
                if (authorizeAttributesWithPolicies.Any())
                {
                    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                    {
                        var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);

                        if (!authorized)
                        {
                            throw new InvalidAccessException();
                        }
                    }
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}
