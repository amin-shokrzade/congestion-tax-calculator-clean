using Domain.Events.TaxFreeDateEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeDates.EventHandlers
{
    public class TaxFreeDateUpdatedEventHandler : INotificationHandler<TaxFreeDateUpdatedEvent>
    {
        private readonly ILogger<TaxFreeDateUpdatedEventHandler> _logger;

        public TaxFreeDateUpdatedEventHandler(ILogger<TaxFreeDateUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeDateUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
