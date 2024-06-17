using Application.EntitiesCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<DatabaseContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class DatabaseContextInitialiser
    {
        private readonly ILogger<DatabaseContextInitialiser> _logger;
        private readonly DatabaseContext _context;
        private readonly ApplicationUserManager<ApplicationUser<Guid>> _userManager;
        private readonly ApplicationRoleManager<ApplicationRole<Guid>> _roleManager;

        public DatabaseContextInitialiser(ILogger<DatabaseContextInitialiser> logger, DatabaseContext context, ApplicationUserManager<ApplicationUser<Guid>> userManager, ApplicationRoleManager<ApplicationRole<Guid>> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            await CreateCity();

            await CreateVehicleTypes();

            await CreateTimeAndTaxAmounts();

            await CreateTaxFreeVehicles();

            await CreateFreeDates();

            await _context.SaveChangesAsync();
        }

        async Task CreateCity()
        {
            if (await _context.Cities.AnyAsync()) return;

            await _context.Cities.AddAsync(new Domain.Entities.City()
            {
                Name = "Gothenburg",
                Id = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                MaxDailyTax = 60,
                SingleChargeRuleTimeInMinute = 60,
                TaxFreeMonths = new List<int>() { 7 },
                TaxFreeWeekDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday },
            }); ;
        }

        async Task CreateVehicleTypes()
        {
            if (await _context.VehicleTypes.AnyAsync()) return;
            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Emergency vehicles",
                Id = Guid.Parse("7819c116-a08c-4b79-a125-73240e688221"),
                SortOrder = 1
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Busses",
                Id = Guid.Parse("bed97c79-fd27-44ba-9095-ee7f1e57899a"),
                SortOrder = 2
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Diplomat vehicles",
                Id = Guid.Parse("852f1d49-b5cb-4a53-859e-372af8fdd455"),
                SortOrder = 3
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Motorcycles",
                Id = Guid.Parse("34128341-baa3-48b1-9f98-8dca038975de"),
                SortOrder = 4
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Military vehicles",
                Id = Guid.Parse("c9fff841-7147-494c-ab00-ec54a4e4f509"),
                SortOrder = 5
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Foreign vehicles",
                Id = Guid.Parse("e7932cba-2c44-4701-9f1f-59103824c86f"),
                SortOrder = 6
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Car",
                Id = Guid.Parse("4b0b4826-8252-4675-a99f-a7f32b650ecd"),
                SortOrder = 7
            });

            await _context.VehicleTypes.AddAsync(new Domain.Entities.VehicleType()
            {
                Title = "Motorbike",
                Id = Guid.Parse("4681c9f9-79fd-4757-9733-6036372750f3"),
                SortOrder = 8
            });
        }

        async Task CreateTimeAndTaxAmounts()
        {
            if (await _context.TimeAndTaxAmounts.AnyAsync()) return;

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("06:00"),
                To = TimeOnly.Parse("06:29"),
                Amount = 8
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("06:30"),
                To = TimeOnly.Parse("06:59"),
                Amount = 13
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("07:00"),
                To = TimeOnly.Parse("07:59"),
                Amount = 18
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("08:00"),
                To = TimeOnly.Parse("08:29"),
                Amount = 13
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("08:30"),
                To = TimeOnly.Parse("14:59"),
                Amount = 8
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("15:00"),
                To = TimeOnly.Parse("15:29"),
                Amount = 13
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("15:30"),
                To = TimeOnly.Parse("16:59"),
                Amount = 18
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("17:00"),
                To = TimeOnly.Parse("17:59"),
                Amount = 13
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("18:00"),
                To = TimeOnly.Parse("18:29"),
                Amount = 8
            });

            await _context.TimeAndTaxAmounts.AddAsync(new Domain.Entities.TimeAndTaxAmount()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                From = TimeOnly.Parse("18:30"),
                To = TimeOnly.Parse("05:59"),
                Amount = 0
            });
        }

        async Task CreateTaxFreeVehicles()
        {
            if (await _context.TaxFreeVehicles.AnyAsync()) return;

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("7819c116-a08c-4b79-a125-73240e688221"),
            });

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("bed97c79-fd27-44ba-9095-ee7f1e57899a")
            });

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("852f1d49-b5cb-4a53-859e-372af8fdd455")
            });

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("34128341-baa3-48b1-9f98-8dca038975de")
            });

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("c9fff841-7147-494c-ab00-ec54a4e4f509")
            });

            await _context.TaxFreeVehicles.AddAsync(new Domain.Entities.TaxFreeVehicle()
            {
                CityId = Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                VehicleTypeId = Guid.Parse("e7932cba-2c44-4701-9f1f-59103824c86f")
            });
        }

        async Task CreateFreeDates()
        {
            if (_context.TaxFreeDates.Any()) return;

            await _context
                .TaxFreeDates
                .AddRangeAsync(new Domain.Entities.TaxFreeDate[]
                {
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-01-01")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-01-06")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-02-14")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-03-28")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-03-29")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-03-31")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-04-01")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-04-30")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-05-01")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-05-09")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-05-19")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-05-26")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-06-06")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-06-21")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-06-22")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-10-27")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-11-02")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-11-10")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-11-11")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-01")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-08")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-13")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-15")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-22")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-24")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-25")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-26")
                    },
                    new Domain.Entities.TaxFreeDate()
                    {
                         CityId=Guid.Parse("7d1fdbf7-26a3-4292-957b-006a43b66a99"),
                          FreeDate=DateOnly.Parse("2013-12-31")
                    }
                });
        }
    }
}
