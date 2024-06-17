
using Domain.Base;

namespace Domain.Entities
{
    public class TaxFreeVehicle:BaseEntityWithAudit
    {
        public TaxFreeVehicle() { }

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;

        public Guid VehicleTypeId {  get; set; }

        public VehicleType VehicleType { get; set; } = null!;

    }
}
