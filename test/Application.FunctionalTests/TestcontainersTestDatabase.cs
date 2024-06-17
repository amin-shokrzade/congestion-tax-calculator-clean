using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace Application.FunctionalTests
{
    public class TestcontainersTestDatabase : ITestDatabase
    {
        private readonly MsSqlContainer _container;
        private DbConnection _connection = null!;
        private string _connectionString = null!;
        private Respawner _respawner = null!;

        public TestcontainersTestDatabase()
        {
            _container = new MsSqlBuilder()
                .WithAutoRemove(true)
                .Build();
        }

        public async Task InitialiseAsync()
        {
            await _container.StartAsync();

            _connectionString = _container.GetConnectionString();

            _connection = new SqlConnection(_connectionString);

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(_connectionString)
                .Options;

            var context = new DatabaseContext(options);

            context.Database.Migrate();

            _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
            {
                TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
            });
        }

        public DbConnection GetConnection()
        {
            return _connection;
        }

        public async Task ResetAsync()
        {
            await _respawner.ResetAsync(_connectionString);
        }

        public async Task DisposeAsync()
        {
            await _connection.DisposeAsync();
            await _container.DisposeAsync();
        }
    }
}
