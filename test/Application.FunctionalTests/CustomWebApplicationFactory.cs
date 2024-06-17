using System.Data.Common;
using Application.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using static Application.FunctionalTests.Testing;

namespace Application.FunctionalTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly DbConnection _connection;

        public CustomWebApplicationFactory(DbConnection connection)
        {
            _connection = connection;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services
                    .RemoveAll<IUser>()
                    .AddTransient(provider => Mock.Of<IUser>(s => s.Id == GetUserId()));

                services
                    .RemoveAll<DbContextOptions<DatabaseContext>>()
                    .AddDbContext<DatabaseContext>((sp, options) =>
                    {
                        options.UseSqlServer(_connection);
                    });
            });
        }
    }
}
