using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vehicle : BaseEntityWithAudit
    {
        protected Vehicle() { }

        [MaxLength(64)]
        public string? Name { get; set; }

        [MaxLength(16)]
        public string? PlateNumber { get; set; }

        public Guid VehicleTypeId { get; set; } 

        public VehicleType VehicleType { get; set; } = null!;
    }
}
