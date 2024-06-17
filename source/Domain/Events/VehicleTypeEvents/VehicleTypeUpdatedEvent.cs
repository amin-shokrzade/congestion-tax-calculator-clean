using Domain.Base;
using Domain.Entities;

namespace Domain.Events.VehicleTypeEvents
{
    public class VehicleTypeUpdatedEvent : BaseEvent
    {
        public VehicleTypeUpdatedEvent(VehicleType item)
        {
            Item = item;
        }

        public VehicleType Item { get; }
    }
}
