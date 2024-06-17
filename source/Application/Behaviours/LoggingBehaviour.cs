using Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly IUser _user;
        private readonly IIdentificationService _identificationService;

        public LoggingBehaviour(ILogger<TRequest> logger, IUser user, IIdentificationService identityService)
        {
            _logger = logger;
            _user = user;
            _identificationService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.Id;
            string? userName = string.Empty;

            if (userId != _identificationService.GetGuestUserId())
            {
                userName = await _identificationService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("Congestion Tax Calculator Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName, request);
        }
    }
}
