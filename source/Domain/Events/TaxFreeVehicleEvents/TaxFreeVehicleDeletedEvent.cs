using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TaxFreeVehicleEvents
{
    public class TaxFreeVehicleDeletedEvent : BaseEvent
    {
        public TaxFreeVehicleDeletedEvent(TaxFreeVehicle item)
        {
            Item = item;
        }

        public TaxFreeVehicle Item { get; }
    }
}
