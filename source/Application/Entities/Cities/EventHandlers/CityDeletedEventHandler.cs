using Domain.Events.CityEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Cities.EventHandlers
{
    public class CityDeletedEventHandler : INotificationHandler<CityDeletedEvent>
    {
        private readonly ILogger<CityDeletedEventHandler> _logger;

        public CityDeletedEventHandler(ILogger<CityDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CityDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
