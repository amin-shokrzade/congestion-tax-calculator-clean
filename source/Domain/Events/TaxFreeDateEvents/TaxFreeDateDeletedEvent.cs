using Domain.Base;
using Domain.Entities;


namespace Domain.Events.TaxFreeDateEvents
{
    public class TaxFreeDateDeletedEvent : BaseEvent
    {
        public TaxFreeDateDeletedEvent(TaxFreeDate item)
        {
            Item = item;
        }

        public TaxFreeDate Item { get; }
    }
}
