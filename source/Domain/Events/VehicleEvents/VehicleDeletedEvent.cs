using Domain.Base;
using Domain.Entities;

namespace Domain.Events.VehicleEvents
{
    public class VehicleDeletedEvent : BaseEvent
    {
        public VehicleDeletedEvent(Vehicle item)
        {
            Item = item;
        }

        public Vehicle Item { get; }
    }
}
