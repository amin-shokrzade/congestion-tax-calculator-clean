using Domain.Events.CityEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Cities.EventHandlers
{
    public class CityInsertedEventHandler : INotificationHandler<CityInsertedEvent>
    {
        private readonly ILogger<CityInsertedEventHandler> _logger;

        public CityInsertedEventHandler(ILogger<CityInsertedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CityInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
