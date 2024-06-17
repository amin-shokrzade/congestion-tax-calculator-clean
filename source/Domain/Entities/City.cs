using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class City : BaseEntityWithAudit
    {
        public City()
        {

        }

        [MaxLength(32)]
        public string Name { get; set; } = null!;

        public int MaxDailyTax { get; set; }

        public int SingleChargeRuleTimeInMinute { get; set; }

        public List<DayOfWeek> TaxFreeWeekDays { get; set; } = new List<DayOfWeek>();

        public List<int> TaxFreeMonths { get; set; } = new List<int>();

        public IList<TaxFreeDate> TaxFreeDates { get; private set; } = new List<TaxFreeDate>();

        public IList<TaxFreeVehicle> TaxFreeVehicles { get; private set; } = new List<TaxFreeVehicle>();

        public IList<TimeAndTaxAmount> TimeAndTaxAmounts { get; private set; } = new List<TimeAndTaxAmount>();
    }
}
