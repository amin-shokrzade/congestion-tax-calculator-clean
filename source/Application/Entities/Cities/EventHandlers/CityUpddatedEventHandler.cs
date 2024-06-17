using Domain.Events.CityEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Cities.EventHandlers
{
    public class CityUpdatedEventHandler : INotificationHandler<CityUpdatedEvent>
    {
        private readonly ILogger<CityUpdatedEventHandler> _logger;

        public CityUpdatedEventHandler(ILogger<CityUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CityUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
