using AutoMapper;
using Domain.Entities;

namespace Application.Entities.Cities.Dtos
{
    public class CityDto
    {
        public CityDto() { }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int MaxDailyTax { get; set; }

        public int SingleChargeRuleTimeInMinute { get; set; }

        public List<DayOfWeek> TaxFreeWeekDays { get; set; } = new List<DayOfWeek>();

        public List<int> TaxFreeMonths { get; set; } = new List<int>();

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<City, CityDto>();
            }
        }
    }
}
