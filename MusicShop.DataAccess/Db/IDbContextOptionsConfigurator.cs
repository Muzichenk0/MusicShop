using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Db
{
    /// <summary>
    /// Абстрактный контракт, описывающий внешний интерфейс для сущностей, настраивающих контекст БД.
    /// </summary>
    /// <typeparam name="TContext">Имя модели - контекст БД. Реализует и зависима от <see cref="DbContext"/></typeparam>
    public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Процедура для настройки контекста базы данных.
        /// На основе информации из json-объектов из файла, выбирает строку для подключения к БД.
        /// </summary>
        /// <param name="optBuilder">Строитель настроек контекста БД</param>
        public void Configure(DbContextOptionsBuilder<TContext> optBuilder);
    }
}
