using Domain.Events.VehicleTypeEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.VehicleTypes.EventHandlers
{
    public class VehicleTypeDeletedEventHandler : INotificationHandler<VehicleTypeDeletedEvent>
    {
        private readonly ILogger<VehicleTypeDeletedEventHandler> _logger;
        public VehicleTypeDeletedEventHandler(ILogger<VehicleTypeDeletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(VehicleTypeDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
