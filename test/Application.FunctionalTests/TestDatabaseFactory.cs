using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FunctionalTests
{
    public static class TestDatabaseFactory
    {
        public static async Task<ITestDatabase> CreateAsync()
        {
            var database = new SqlServerTestDatabase();

            await database.InitialiseAsync();

            return database;
        }
    }
}
