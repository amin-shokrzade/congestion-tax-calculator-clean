using Domain.Events.VehicleTypeEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.VehicleTypes.EventHandlers
{
    public class VehicleTypeInsertedEventHandler : INotificationHandler<VehicleTypeInsertedEvent>
    {
        private readonly ILogger<VehicleTypeInsertedEventHandler> _logger;
        public VehicleTypeInsertedEventHandler(ILogger<VehicleTypeInsertedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleTypeInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
