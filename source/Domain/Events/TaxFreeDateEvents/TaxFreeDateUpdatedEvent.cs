using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TaxFreeDateEvents
{
    public class TaxFreeDateUpdatedEvent : BaseEvent
    {
        public TaxFreeDateUpdatedEvent(TaxFreeDate item)
        {
            Item = item;
        }

        public TaxFreeDate Item { get; }
    }
}
