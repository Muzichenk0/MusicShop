using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MusicShop.Migrator
{
    /// <summary>
    /// Класс, хранящий методы расширения для абстрактного типа-контракта <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление зависимостей в IOC контейнер.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbConnections(configuration);
            return services;
        }

        /// <summary>
        /// Конфигурация процесса подключений к БД.
        /// </summary>
        private static IServiceCollection ConfigureDbConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
