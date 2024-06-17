using Domain.Base;
using Domain.Entities;

namespace Domain.Events.CityEvents
{
    public class CityUpdatedEvent : BaseEvent
    {
        public CityUpdatedEvent(City item)
        {
            Item = item;
        }

        public City Item { get; }
    }
}
