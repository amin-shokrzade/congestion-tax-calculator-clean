using AutoMapper;
using Domain.Entities;

namespace Application.Entities.VehicleTypes.Dtos
{
    public class VehicleTypeDto
    {
        public VehicleTypeDto() { }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsTollFree { get; set; }

        public int SortOrder { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<VehicleType, VehicleTypeDto>();
            }
        }
    }
}
