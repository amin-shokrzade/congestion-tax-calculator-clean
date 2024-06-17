using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TaxFreeVehicleEvents
{
    public class TaxFreeVehicleUpdatedEvent : BaseEvent
    {
        public TaxFreeVehicleUpdatedEvent(TaxFreeVehicle item)
        {
            Item = item;
        }

        public TaxFreeVehicle Item { get; }
    }
}
