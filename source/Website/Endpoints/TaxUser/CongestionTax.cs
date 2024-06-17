using Application.Entities.Vehicles.Queries;
using MediatR;
using Website.Infrastructure;

namespace Website.Endpoints.TaxUser
{
    public class CongestionTax : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapPost(TUGetVehicleCongestiionTax, "GetVehicleCongestiionTax");
        }

        public async Task<int> TUGetVehicleCongestiionTax(ISender sender, GetVehicleCongestiionTaxQuery command)
        {
            return await sender.Send(command);
        }
    }
}
