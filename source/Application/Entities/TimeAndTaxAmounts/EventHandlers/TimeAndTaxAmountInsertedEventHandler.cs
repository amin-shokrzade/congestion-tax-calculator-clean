using Domain.Events.TimeAndTaxAmountEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TimeAndTaxAmounts.EventHandlers
{
    public class TimeAndTaxAmountInsertedEventHandler : INotificationHandler<TimeAndTaxAmountInsertedEvent>
    {
        private readonly ILogger<TimeAndTaxAmountInsertedEventHandler> _logger;
        public TimeAndTaxAmountInsertedEventHandler(ILogger<TimeAndTaxAmountInsertedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TimeAndTaxAmountInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
