using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TimeAndTaxAmountEvents
{
    public class TimeAndTaxAmountUpdatedEvent : BaseEvent
    {
        public TimeAndTaxAmountUpdatedEvent(TimeAndTaxAmount item)
        {
            Item = item;
        }

        public TimeAndTaxAmount Item { get; }
    }
}
