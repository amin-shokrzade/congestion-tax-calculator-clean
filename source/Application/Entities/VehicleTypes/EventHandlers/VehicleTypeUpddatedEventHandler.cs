using Domain.Events.VehicleTypeEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.VehicleTypes.EventHandlers
{
    public class VehicleTypeUpdatedEventHandler : INotificationHandler<VehicleTypeUpdatedEvent>
    {
        private readonly ILogger<VehicleTypeUpdatedEventHandler> _logger;

        public VehicleTypeUpdatedEventHandler(ILogger<VehicleTypeUpdatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleTypeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
