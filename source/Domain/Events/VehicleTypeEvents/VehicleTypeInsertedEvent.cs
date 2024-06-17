using Domain.Base;
using Domain.Entities;

namespace Domain.Events.VehicleTypeEvents
{
    public class VehicleTypeInsertedEvent : BaseEvent
    {
        public VehicleTypeInsertedEvent(VehicleType item)
        {
            Item = item;
        }

        public VehicleType Item { get; }
    }
}
