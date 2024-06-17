using Domain.Base;

namespace Domain.Entities
{
    public class TimeAndTaxAmount : BaseEntityWithAudit
    {
        public TimeAndTaxAmount() { }

        public TimeOnly From { get; set; }

        public TimeOnly To { get; set; }

        public int Amount {  get; set; }

        public Guid CityId {  get; set; }

        public City City { get; set; } = null!;
    }


}
