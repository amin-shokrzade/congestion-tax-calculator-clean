using Domain.Events.TimeAndTaxAmountEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TimeAndTaxAmounts.EventHandlers
{
    public class TimeAndTaxAmountDeletedEventHandler : INotificationHandler<TimeAndTaxAmountDeletedEvent>
    {
        private readonly ILogger<TimeAndTaxAmountDeletedEventHandler> _logger;
        public TimeAndTaxAmountDeletedEventHandler(ILogger<TimeAndTaxAmountDeletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TimeAndTaxAmountDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
