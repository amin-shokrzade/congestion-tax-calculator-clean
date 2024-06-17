using Domain.Base;
using Domain.Entities;

namespace Domain.Events.CityEvents
{
    public class CityDeletedEvent : BaseEvent
    {
        public CityDeletedEvent(City item)
        {
            Item = item;
        }

        public City Item { get; }
    }
}
