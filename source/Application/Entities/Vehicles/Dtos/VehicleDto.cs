using AutoMapper;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Entities.Vehicles.Dtos
{
    public class VehicleDto
    {
        public VehicleDto() { }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? PlateNumber { get; set; }

        public Guid VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Vehicle, VehicleDto>();
            }
        }
    }
}
