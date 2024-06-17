using Domain.Base;
using Domain.Entities;

namespace Domain.Events.TaxFreeVehicleEvents
{
    public class TaxFreeVehicleInsertedEvent : BaseEvent
    {
        public TaxFreeVehicleInsertedEvent(TaxFreeVehicle item)
        {
            Item = item;
        }

        public TaxFreeVehicle Item { get; }
    }
}
