

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MusicShop.DataAccess.Db
{
    /// <summary>
    /// Определеяет внутренний, внешний интерфейс для конфигурации контекста базы данных.
    /// </summary>
    public class DbContextConfiguration : IDbContextOptionsConfigurator<DbAppContext>
    {
        /// <summary>
        /// Поле с конкретной сущностью из зависимости.
        /// Текущая настройка сборки.
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Поле с конкретной сущностью из зависимости.
        /// Выбранная фабрика для логгеров.
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;
        public DbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }
        
        /// <exception cref="InvalidOperationException">Отсутствует пара ключ-значение, содержащая строку подключения к БД, в json файле.</exception>
        public void Configure(DbContextOptionsBuilder<DbAppContext> optBuilder)
        {
            var connectionString = _configuration.GetConnectionString("Default");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не обнаружена строка подключения с именем 'Default' из узлов json объекта");
            }
            optBuilder.UseNpgsql(connectionString);
            optBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
