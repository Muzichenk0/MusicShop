using MusicShop.Contracts.File;

namespace MusicShop.AppData.Contexts.SiteFile.Repository
{
    /// <summary>
    /// Абстрактный тип, контракт, описывающий внешнее поведение модели - репозитория файла сайта
    /// </summary>
    public interface ISiteFileRepository
    {
        /// <summary>
        /// Получение перечисления из <see cref="SiteFileInfoResponse"/>, асинхронно
        /// </summary>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns>Перечисление, сформированное в оптимизированный запрос, из экземпляров <see cref="SiteFileInfoResponse"/></returns>
        public Task<IQueryable<SiteFileInfoResponse?>> GetAllFilesAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение существующего файла, чей id согласован с <paramref name="fileId"/>, асинхронно
        /// </summary>
        /// <param name="fileId">Идентификатор файла</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns>Экземпляр <see cref="SiteFileInfoResponse"/></returns>
        public Task<SiteFileInfoResponse?> GetFileByIdAsync(Guid fileId, CancellationToken cancelToken = default);
        /// <summary>
        /// Создание нового файла, асинхронно
        /// </summary>
        /// <param name="fileToCreate">Состояние файла </param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns><see cref="Guid"/> добавленного в БД файла</returns>
        public Task<Guid> CreateFileAsync(CreateSiteFileRequest fileToCreate, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление существующего файла, асинхронно
        /// </summary>
        /// <param name="fileToDelete">Состояние файла из запроса, для удаления</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        public Task DeleteFileAsync(DeleteSiteFileRequest fileToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление существующего файла, асинхронно
        /// </summary>
        /// <param name="fileId">Идентификатор файла</param>
        /// <param name="fileToUpdate">Состояние файла из запроса, для обновления</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        public Task UpdateFileAsync(Guid fileId, UpdateSiteFileRequest fileToUpdate, CancellationToken cancelToken = default);
    }
}
