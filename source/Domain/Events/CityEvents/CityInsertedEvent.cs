using Domain.Base;
using Domain.Entities;

namespace Domain.Events.CityEvents
{
    public class CityInsertedEvent : BaseEvent
    {
        public CityInsertedEvent(City item)
        {
            Item = item;
        }

        public City Item { get; }
    }
}
