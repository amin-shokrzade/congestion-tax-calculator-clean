using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TimeAndTaxAmountEvents
{
    public class TimeAndTaxAmountInsertedEvent : BaseEvent
    {
        public TimeAndTaxAmountInsertedEvent(TimeAndTaxAmount item)
        {
            Item = item;
        }

        public TimeAndTaxAmount Item { get; }
    }
}
