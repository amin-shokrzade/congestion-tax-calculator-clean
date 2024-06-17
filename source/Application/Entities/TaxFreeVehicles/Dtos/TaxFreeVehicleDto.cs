using Application.Entities.Cities.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.TaxFreeVehicles.Dtos
{
    public class TaxFreeVehicleDto
    {
        public TaxFreeVehicleDto() { }

        public Guid Id { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;

        public Guid VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TaxFreeVehicle, TaxFreeVehicleDto>();
            }
        }
    }
}
