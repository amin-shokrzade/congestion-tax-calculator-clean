using Application.Entities.Vehicles.Queries;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities.Vehicles.Validators
{
    public class GetVehicleCongestiionTaxQueryValidator : AbstractValidator<GetVehicleCongestiionTaxQuery>
    {
        public GetVehicleCongestiionTaxQueryValidator(IDatabaseContext context, IUser iUser)
        {
            IDatabaseContext _context = context;

            var userId = iUser.Id;

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Dates)
                .NotNull()
                .WithSeverity(Severity.Error)
                .WithName("Date List")
                .WithMessage("Date list is null");

            RuleFor(p => p.Dates)
                .NotEmpty()
                .WithSeverity(Severity.Error)
                .WithName("Date List")
                .WithMessage("Date list is empty");

            RuleFor(p => p.CityId)
                .MustAsync(async (cityId, ct) => await IsValidCityId(cityId, _context, ct))
                .WithSeverity(Severity.Error)
                .WithName("City Id")
                .WithMessage("City ID is not valid");

            RuleFor(p => p.Vehicle.VehicleTypeId)
                .MustAsync(async (vehicleTypeId, ct) => await IsValidVehicleTypeId(vehicleTypeId, _context, ct))
                .WithSeverity(Severity.Error)
                .WithName("Vehicle Type ID")
                .WithMessage("Vehicle Type ID is not valid");
        }

        async Task<bool> IsValidCityId(Guid cityId, IDatabaseContext idatabaseContext, CancellationToken cancellationToken)
        {
            return await idatabaseContext.Cities.AnyAsync(city => city.Deleted == false && city.Id == cityId);
        }

        async Task<bool> IsValidVehicleTypeId(Guid vehicleId, IDatabaseContext idatabaseContext, CancellationToken cancellationToken)
        {
            return await idatabaseContext.VehicleTypes.AnyAsync(vehicleType => vehicleType.Deleted == false && vehicleType.Id == vehicleId);
        }
    }
}
