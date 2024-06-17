using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TaxFreeDateEvents
{
    public class TaxFreeDateInsertedEvent : BaseEvent
    {
        public TaxFreeDateInsertedEvent(TaxFreeDate item)
        {
            Item = item;
        }

        public TaxFreeDate Item { get; }
    }
}
