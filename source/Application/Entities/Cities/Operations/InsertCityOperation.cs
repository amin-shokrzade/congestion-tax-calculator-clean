using Application.Interfaces;
using Domain.Entities;
using Domain.Events.CityEvents;
using MediatR;

namespace Application.Entities.Cities.Operations
{
    public record InsertCityOperation : IRequest<Guid>
    {
        public string Name { get; set; } = null!;

        public int MaxDailyTax { get; set; }

        public int SingleChargeRuleTimeInMinute { get; set; }

        public List<DayOfWeek> TaxFreeWeekDays { get; set; } = new List<DayOfWeek>();

        public List<int> TaxFreeMonths { get; set; } = new List<int>();
    }

    public class InsertCityOperationHandler : IRequestHandler<InsertCityOperation, Guid>
    {
        private readonly IDatabaseContext _context;

        public InsertCityOperationHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(InsertCityOperation request, CancellationToken cancellationToken)
        {
            var entity = new City()
            {
                Name = request.Name,
                MaxDailyTax = request.MaxDailyTax,
                SingleChargeRuleTimeInMinute = request.SingleChargeRuleTimeInMinute,
                TaxFreeWeekDays = request.TaxFreeWeekDays,
                TaxFreeMonths = request.TaxFreeMonths
            };

            entity.AddEvent(new CityInsertedEvent(entity));

            _context.Cities.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
