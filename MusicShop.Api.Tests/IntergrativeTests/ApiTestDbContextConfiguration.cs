using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.DataAccess.Db;

namespace MusicShop.Api.Tests
{
    public class ApiTestDbContextConfiguration : IDbContextOptionsConfigurator<DbAppContext>
    {
        public const string InMemoryDatabaseName = "MusicShopTestDb";

        private readonly ILoggerFactory _loggerFactory;

        public ApiTestDbContextConfiguration(ILoggerFactory loggerFactory)
            => _loggerFactory = loggerFactory;

        public void Configure(DbContextOptionsBuilder<DbAppContext> dbOptBuilder)
        {
            dbOptBuilder.UseInMemoryDatabase(InMemoryDatabaseName);
            dbOptBuilder.UseLoggerFactory(_loggerFactory);
            dbOptBuilder.EnableSensitiveDataLogging();
        }
    }
}
