namespace MusicShop.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Абстрактная сущность - контракт, описывающая внешний интерфейс репозитория, взаимодействующего с БД.
    /// </summary>
    /// <typeparam name="T">Обобщенный ссылочный тип</typeparam>
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Получение всей информации асинхронно
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи.</param>
        /// <returns>Выстроенное в оптимизированные запрос, перечисление из <see cref="T"/></returns>
        public Task<IQueryable<T>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение всей информации, отфильтрованной, асинхронно
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи.</param>
        public Task<IQueryable<T>> GetAllFilteredAsync(Func<T,bool> predicateFilter , CancellationToken cancelToken = default);
        /// <summary>
        /// Получение информации через идентификатор, асинхронно
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи.</param>
        public Task<T> GetByIdAsync(Guid id, CancellationToken cancelToken = default);
        /// <summary>
        /// Получение объекта типа <see cref="T"/>, асинхронным образом
        /// </summary>
        /// <param name="objToUpdate">Объект для обновления.</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи.</param>
        public Task UpdateAsync(T objToUpdate, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление объекта типа <see cref="T"/>
        /// </summary>
        /// <param name="objToAdd">Объект для добавление</param>
        /// <param name="cancelToken"></param>
        public Task AddAsync(T objToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление объекта типа <see cref="T"/>
        /// </summary>
        /// <param name="objToDelete"></param>
        /// <param name="cancelToken"></param>
        public Task DeleteAsync(T objToDelete, CancellationToken cancelToken = default);
    }
}
