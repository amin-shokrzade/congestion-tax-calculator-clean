using Domain.Events.TaxFreeDateEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entities.TaxFreeDates.EventHandlers
{
    public class TaxFreeDateDeletedEventHandler : INotificationHandler<TaxFreeDateDeletedEvent>
    {
        private readonly ILogger<TaxFreeDateDeletedEventHandler> _logger;

        public TaxFreeDateDeletedEventHandler(ILogger<TaxFreeDateDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TaxFreeDateDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Congestion Tax Calculator Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
