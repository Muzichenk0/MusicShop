using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MusicShop.Migrator
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление сервисов.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbConnections(configuration);
            return services;
        }

        /// <summary>
        /// Конфигурация подключения к БД.
        /// </summary>
        private static IServiceCollection ConfigureDbConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<MigrationDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
