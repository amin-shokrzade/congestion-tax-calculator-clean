using Domain.Base;
using Domain.Entities;


namespace Domain.Events.VehicleTypeEvents
{
    public class VehicleTypeDeletedEvent : BaseEvent
    {
        public VehicleTypeDeletedEvent(VehicleType item)
        {
            Item = item;
        }

        public VehicleType Item { get; }
    }
}
