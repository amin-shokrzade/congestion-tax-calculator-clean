using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICongestionTaxCalculator
    {
        public Task<int> CalcTax(City city, VehicleType vehicleType, IReadOnlyCollection<DateTime> dates);
    }
}
