using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MusicShop.Migrator
{
    /// <summary>
    /// Фабрика по производству контекста о базе данных, для миграций.
    /// </summary>
    public class MigrationDbContextFactory: IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string? connectionString = configuration.GetConnectionString("Default");

            DbContextOptionsBuilder<MigrationDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
            dbContextOptionsBuilder.UseNpgsql(connectionString);
            return new MigrationDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
