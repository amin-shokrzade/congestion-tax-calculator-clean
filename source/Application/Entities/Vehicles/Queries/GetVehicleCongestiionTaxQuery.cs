using Application.Entities.Vehicles.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities.Vehicles.Queries
{
    public record GetVehicleCongestiionTaxQuery : IRequest<int>
    {
        public GetVehicleCongestiionTaxQuery() { }

        public Guid CityId { get; set; }

        public VehicleBrifeDto Vehicle { get; set; } = null!;

        public IReadOnlyCollection<DateTime> Dates { get; set; } = null!;

        public Guid userId;
    }

    public class GetVehicleCongestiionTaxQueryHandler : IRequestHandler<GetVehicleCongestiionTaxQuery, int>
    {
        private readonly IDatabaseContext _context;
        private readonly IUser _iUser;
        private readonly IIdentificationService _identificationService;
        private readonly ICongestionTaxCalculator _congestionTaxCalculator;

        public GetVehicleCongestiionTaxQueryHandler(IDatabaseContext context, IUser iUser, IIdentificationService identificationService, ICongestionTaxCalculator congestionTaxCalculator)
        {
            _context = context;
            _iUser = iUser;
            _identificationService = identificationService;
            _congestionTaxCalculator = congestionTaxCalculator;
        }

        public async Task<int> Handle(GetVehicleCongestiionTaxQuery request, CancellationToken cancellationToken)
        {
            request.userId = _iUser.Id;

            var taxCity =await _context.Cities.FirstAsync(city => city.Id == request.CityId);

            var taxVehicleType = await _context.VehicleTypes.FirstAsync(vehicleType => vehicleType.Id == request.Vehicle.VehicleTypeId);

            return await _congestionTaxCalculator.CalcTax(taxCity, taxVehicleType, request.Dates);
        }
    }
}
