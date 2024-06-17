using Application.Entities.Cities.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.TimeAndTaxAmounts.Dtos
{
    public class TimeAndTaxAmountDto
    {
        public TimeAndTaxAmountDto() { }

        public Guid Id { get; set; }

        public TimeOnly From { get; set; }

        public TimeOnly To { get; set; }

        public int Amount { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TimeAndTaxAmount, TimeAndTaxAmountDto>();
            }
        }
    }
}
