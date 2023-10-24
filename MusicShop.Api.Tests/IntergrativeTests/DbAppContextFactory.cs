using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.Api.Tests.IntegrationTests;
using MusicShop.DataAccess.Db;

namespace MusicShop.Api.Tests.IntergrativeTests
{
    /// <summary>
    /// Фабрика для производства контекстов базы данных сборки
    /// </summary>
    public class DbAppContextFactory : WebApplicationFactory<WebApi.Program>
    {
        /// <summary>
        /// Определение базовых настроек сервера
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((services) =>
            {
                ServiceDescriptor? descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IDbContextOptionsConfigurator<DbAppContext>));

                services.Remove(descriptor!);

                services.AddSingleton<IDbContextOptionsConfigurator<DbAppContext>, ApiTestDbContextConfiguration>();

                IServiceProvider serviceProvider = services.BuildServiceProvider();

                using IServiceScope scope = serviceProvider.CreateScope();

                IServiceProvider? scopedServices = scope.ServiceProvider;

                DbAppContext db = scopedServices.GetRequiredService<DbAppContext>();

                db.Database.EnsureCreated();

                DataSeedHelper.InitializeDbForTests(db);
            });
        }
        /// <summary>
        /// Создать контекст тестовой БД.
        /// </summary>
        public DbAppContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbAppContext>();
            optionsBuilder.UseInMemoryDatabase(ApiTestDbContextConfiguration.InMemoryDatabaseName);
            optionsBuilder.EnableSensitiveDataLogging();
            var dbContext = new DbAppContext(optionsBuilder.Options);
            return dbContext;
        }
    }

}
