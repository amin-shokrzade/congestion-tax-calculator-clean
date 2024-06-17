using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TimeAndTaxAmountEvents
{
    public class TimeAndTaxAmountDeletedEvent : BaseEvent
    {
        public TimeAndTaxAmountDeletedEvent(TimeAndTaxAmount item)
        {
            Item = item;
        }

        public TimeAndTaxAmount Item { get; }
    }
}
