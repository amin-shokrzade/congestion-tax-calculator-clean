using Domain.Events.VehicleEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.Vehicles.EventHandlers
{
    public class VehicleUpdatedEventHandler : INotificationHandler<VehicleUpdatedEvent>
    {
        private readonly ILogger<VehicleUpdatedEventHandler> _logger;
        public VehicleUpdatedEventHandler(ILogger<VehicleUpdatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
