using Domain.Events.TaxFreeDateEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeDates.EventHandlers
{
    public class TaxFreeDateInsertedEventHandler : INotificationHandler<TaxFreeDateInsertedEvent>
    {
        private readonly ILogger<TaxFreeDateInsertedEventHandler> _logger;

        public TaxFreeDateInsertedEventHandler(ILogger<TaxFreeDateInsertedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeDateInsertedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
