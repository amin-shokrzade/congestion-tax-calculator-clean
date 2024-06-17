using Domain.Events.VehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Vehicles.EventHandlers
{
    public class VehicleDeletedEventHandler : INotificationHandler<VehicleDeletedEvent>
    {
        private readonly ILogger<VehicleDeletedEventHandler> _logger;
        public VehicleDeletedEventHandler(ILogger<VehicleDeletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
