using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleType:BaseEntityWithAudit
    {
        public VehicleType() { }

        [MaxLength(32)]
        public string Title { get; set; } = null!;

        public int SortOrder { get; set; }

        public IList<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public IList<TaxFreeVehicle> TaxFreeVehicles { get; private set; } = new List<TaxFreeVehicle>();
    }
}
