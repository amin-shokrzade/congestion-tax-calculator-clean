using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Vehicles.Dtos
{
    public class VehicleBrifeDto
    {
        public VehicleBrifeDto() { }

        public string? Name { get; set; }

        public string? PlateNumber { get; set; }

        public Guid VehicleTypeId { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Vehicle, VehicleBrifeDto>();
            }
        }
    }
}
