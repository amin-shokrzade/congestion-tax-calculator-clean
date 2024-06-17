using Domain.Events.TimeAndTaxAmountEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TimeAndTaxAmounts.EventHandlers
{
    public class TimeAndTaxAmountUpdatedEventHandler : INotificationHandler<TimeAndTaxAmountUpdatedEvent>
    {
        private readonly ILogger<TimeAndTaxAmountUpdatedEventHandler> _logger;
        public TimeAndTaxAmountUpdatedEventHandler(ILogger<TimeAndTaxAmountUpdatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TimeAndTaxAmountUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
