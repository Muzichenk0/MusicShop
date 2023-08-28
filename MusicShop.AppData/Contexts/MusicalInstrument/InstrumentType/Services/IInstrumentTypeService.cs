using MusicShop.Contracts.InstrumentType;

namespace MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Services
{
    /// <summary>
    /// Абстрактный тип - контракт, описывающий внешний интерфейс модели - сервис типа инструмента.
    /// </summary>
    public interface IInstrumentTypeService
    {
        /// <summary>
        /// Получение всех типов инструментов, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        /// <returns>Выстроенное в оптимизированный запрос, перечисление из экземпляров <see cref="InstrumentTypeResponseInfo"/></returns>
        public Task<IQueryable<InstrumentTypeResponseInfo>> GetAllInstrumentTypesAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение типа инструмента, чей ID согласован с <paramref name="instTypeId", асинхронно.
        /// </summary>
        /// <param name="instTypeId"></param>
        /// <param name="cancelToken"></param>
        /// <returns>Экземпляр сущности <see cref="InstrumentTypeResponseInfo"/> с идентификатором - <paramref name="instTypeId"/></returns>
        public Task<InstrumentTypeResponseInfo> GetInstrumentTypeByIdAsync(Guid instTypeId, CancellationToken cancelToken = default);
        /// <summary>
        /// Добавление нового типа инструмента, на основе <paramref name="instTypeToAdd"/>, асинхронно.
        /// </summary>
        /// <param name="instTypeToAdd">Информация о типе инструмента для добавления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        public Task AddInstrumentTypeAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление существующего типа инструмента, асинхронно.
        /// </summary>
        /// <param name="instTypeToDelete">Информация о типе инструмента для удаления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        public Task DeleteInstrumentTypeAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление существующего типа инструмента, чей ID согласован с <paramref name="instTypeId"/>,
        /// с помощью данных из интерфейса экземпляра <paramref name="instTypeToUpdate"/>, асинхронно.
        /// </summary>
        /// <param name="instTypeId">Идентификтор типа инструмента</param>
        /// <param name="instTypeToUpdate">Информация о типе инструмента для обновления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной операции</param>
        public Task UpdateInstrumentTypeAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default);
    }
}
