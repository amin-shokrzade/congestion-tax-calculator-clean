using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly IUser _user;
        private readonly IIdentificationService _identificationService;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            IUser user,
            IIdentificationService identificationService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _user = user;
            _identificationService = identificationService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _user.Id;
                var userName = string.Empty;

                if (userId != _identificationService.GetGuestUserId())
                {
                    userName = await _identificationService.GetUserNameAsync(userId);
                }

                _logger.LogWarning("Congestion Tax Calculator Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                    requestName, elapsedMilliseconds, userId, userName, request);
            }

            return response;
        }
    }
}
