using Domain.Events.VehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Vehicles.EventHandlers
{
    public class VehicleInsertedEventHandler : INotificationHandler<VehicleInsertedEvent>
    {
        private readonly ILogger<VehicleInsertedEventHandler> _logger;
        public VehicleInsertedEventHandler(ILogger<VehicleInsertedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
