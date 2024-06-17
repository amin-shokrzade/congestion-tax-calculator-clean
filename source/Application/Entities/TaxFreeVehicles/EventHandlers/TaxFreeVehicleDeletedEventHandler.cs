using Domain.Events.TaxFreeVehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeVehicles.EventHandlers
{
    public class TaxFreeVehicleDeletedEventHandler : INotificationHandler<TaxFreeVehicleDeletedEvent>
    {
        private readonly ILogger<TaxFreeVehicleDeletedEventHandler> _logger;

        public TaxFreeVehicleDeletedEventHandler(ILogger<TaxFreeVehicleDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeVehicleDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
