using AutoMapper;
using Domain.Entities;

namespace Application.Entities.TaxFreeDates.Dtos
{
    public class TaxFreeDateDto
    {
        public TaxFreeDateDto() { }

        public Guid Id { get; set; }

        public DateOnly FreeDate;

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TaxFreeDate, TaxFreeDateDto>();
            }
        }
    }
}
