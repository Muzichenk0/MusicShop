using MusicShop.Contracts.MusicalInstrument;

namespace MusicShop.AppData.Contexts.MusicalInstrument.Repository
{
    /// <summary>
    /// Абстрактный тип - контракт, описывающий внешний интерфейс для сущности - репозиторий музыкального инструмента
    /// </summary>
    public interface IMusicalInstrumentRepository
    {
        /// <summary>
        /// Получение всех музыкальных инструментов, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        /// <returns>Помещенное в оптимизированный запрос, перечисление из экземпляров <see cref="MusicalInstrumentResponseInfo"/></returns>
        public Task<IQueryable<MusicalInstrumentResponseInfo>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение музыкального инструмента, чей ID согласован с <paramref name="musInstrumentId"/>, асинхронно.
        /// </summary>
        /// <param name="musInstrumentId"></param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        /// <returns>Экземпляр <see cref="MusicalInstrumentResponseInfo"/>, чей ID согласован с <paramref name="musInstrumentId"/> </returns>
        public Task<MusicalInstrumentResponseInfo> GetByIdAsync(Guid musInstrumentId, CancellationToken cancelToken = default);
        /// <summary>
        /// Добавление нового музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musInstrumentToAdd">Информация о музыкальном инструменте, для добавления записи в таблицу БД</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        public Task AddAsync(CreateMusicalInstrumentRequest musInstrumentToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление существующего музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musInstrumentToDelete">Информация о музыкальном инструменте, для удаления записи из таблицы БД</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        public Task DeleteAsync(DeleteMusicalInstrumentRequest musInstrumentToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление существующего музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musInstrumentToUpdate">Информация о музыкальном инструменте, для обновления записи в таблице БД</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        /// <param name="musInstrumentId">Идентификатор музыкального инструмента</param>
        public Task UpdateAsync(Guid musInstrumentId, UpdateMusicalInstrumentRequest musInstrumentToUpdate, CancellationToken cancelToken = default);
    }
}
