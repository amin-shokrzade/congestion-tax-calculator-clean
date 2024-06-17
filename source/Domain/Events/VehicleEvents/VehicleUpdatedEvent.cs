using Domain.Base;
using Domain.Entities;


namespace Domain.Events.VehicleEvents
{
    public class VehicleUpdatedEvent : BaseEvent
    {
        public VehicleUpdatedEvent(Vehicle item)
        {
            Item = item;
        }

        public Vehicle Item { get; }
    }
}
