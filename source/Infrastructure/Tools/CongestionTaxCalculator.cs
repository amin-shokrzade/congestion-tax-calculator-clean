using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Tools
{
    public class CongestionTaxCalculator : ICongestionTaxCalculator
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configurationManager;

        public CongestionTaxCalculator(IDatabaseContext context, IConfiguration configurationManager)
        {
            _context = context;
            _configurationManager = configurationManager;
        }
        public async Task<int> CalcTax(City city, VehicleType vehicleType, IReadOnlyCollection<DateTime> dates)
        {
            int sum = 0;

            // ### Tax Exempt vehicles
            if (await IsTaxExemptVehicle(city.Id, vehicleType.Id)) return sum;

            // Get City tax charges
            var cityTaxCharges= await _context.TimeAndTaxAmounts.Where(x => x.Deleted == false && x.CityId == city.Id).ToListAsync();

            // Group dates based on date only
            var dateGroups = dates.GroupBy(date => date.Date);

            foreach (var dateGroup in dateGroups)
            {
                int tempSum = 0;
                var groupitems = dateGroup.Select(item => item).Order().ToList();
                // Check The single charge rule
                if (groupitems.Count > 1 && SingleChargeRule(city,groupitems))
                {
                    sum += GetMaxValueForSingleChargeRule(cityTaxCharges, groupitems);
                    continue;
                }

                foreach (var date in groupitems)
                {
                    if (tempSum >= city.MaxDailyTax) break;
                    if (IsTaxFreeMonth(city, date) || IsTaxFreeDayofWeek(city, date) || await IsTaxFreeHoliday(city.Id, date))
                    {
                        continue;
                    }
                    tempSum += cityTaxCharges.FirstOrDefault(charge => charge.From <= TimeOnly.FromDateTime(date) && charge.To >= TimeOnly.FromDateTime(date))?.Amount ?? 0;
                }
                sum += Math.Min(tempSum, city.MaxDailyTax);
            }
            return sum;
        }

        async Task<bool> IsTaxExemptVehicle(Guid cityId, Guid vehicleTypeId)
        {
            return await _context
                .TaxFreeVehicles
                .AnyAsync(taxfreevehicle => taxfreevehicle.Deleted == false && taxfreevehicle.CityId == cityId && taxfreevehicle.VehicleTypeId == vehicleTypeId);
        }

        bool IsTaxFreeMonth(City city, DateTime date)
        {
            return city.TaxFreeMonths.Any(month => month == date.Month);
        }

        bool IsTaxFreeDayofWeek(City city, DateTime date)
        {
            return city.TaxFreeWeekDays.Any(day => day == date.DayOfWeek);
        }

        async Task<bool> IsTaxFreeHoliday(Guid cityId,DateTime date)
        {
            return await _context
                .TaxFreeDates
                .AnyAsync(freedate => freedate.Deleted == false && freedate.CityId == cityId && freedate.FreeDate == DateOnly.FromDateTime(date.Date) || freedate.FreeDate.AddDays(-1) == DateOnly.FromDateTime(date.Date));
        }

        bool SingleChargeRule(City city, IReadOnlyCollection<DateTime> dates)
        {
            var timeDiff = dates.FirstOrDefault() - dates.LastOrDefault();
            return timeDiff.TotalMinutes <= city.SingleChargeRuleTimeInMinute;
        }

        int GetMaxValueForSingleChargeRule(List<TimeAndTaxAmount> charges, IReadOnlyCollection<DateTime> dates)
        {
            return charges
                .Where(charge => dates.Any(date => charge.From <= TimeOnly.FromDateTime(date) && charge.To <= TimeOnly.FromDateTime(date))).Max(x => x.Amount);
        }
    }
}
