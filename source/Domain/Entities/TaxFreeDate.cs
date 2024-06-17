using Domain.Base;

namespace Domain.Entities
{
    public class TaxFreeDate:BaseEntityWithAudit
    {
        public TaxFreeDate() { }

        public DateOnly FreeDate;

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;
    }
}
