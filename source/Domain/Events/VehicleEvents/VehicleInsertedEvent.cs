using Domain.Base;
using Domain.Entities;


namespace Domain.Events.VehicleEvents
{
    public class VehicleInsertedEvent : BaseEvent
    {
        public VehicleInsertedEvent(Vehicle item)
        {
            Item = item;
        }

        public Vehicle Item { get; }
    }
}
