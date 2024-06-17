using Domain.Events.TaxFreeVehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeVehicles.EventHandlers
{
    public class TaxFreeVehicleUpdatedEventHandler : INotificationHandler<TaxFreeVehicleUpdatedEvent>
    {
        private readonly ILogger<TaxFreeVehicleUpdatedEventHandler> _logger;

        public TaxFreeVehicleUpdatedEventHandler(ILogger<TaxFreeVehicleUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeVehicleUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
