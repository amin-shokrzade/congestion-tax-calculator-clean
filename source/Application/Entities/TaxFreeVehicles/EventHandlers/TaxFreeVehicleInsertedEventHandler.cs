using Domain.Events.TaxFreeVehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeVehicles.EventHandlers
{
    public class TaxFreeVehicleInsertedEventHandler : INotificationHandler<TaxFreeVehicleInsertedEvent>
    {
        private readonly ILogger<TaxFreeVehicleInsertedEventHandler> _logger;

        public TaxFreeVehicleInsertedEventHandler(ILogger<TaxFreeVehicleInsertedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeVehicleInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
