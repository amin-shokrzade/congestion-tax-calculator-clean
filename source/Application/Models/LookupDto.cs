using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LookupDto
    {
        public Guid Id { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<City, LookupDto>();
                CreateMap<TaxFreeDate, LookupDto>();
                CreateMap<TaxFreeVehicle, LookupDto>();
                CreateMap<TimeAndTaxAmount, LookupDto>();
                CreateMap<Vehicle, LookupDto>();
                CreateMap<VehicleType, LookupDto>();
            }
        }
    }
}
