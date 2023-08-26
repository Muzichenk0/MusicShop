using MusicShop.Contracts.SellerReview;

namespace MusicShop.AppData.Contexts.SellerReview.Repository
{
    /// <summary>
    /// Абстрактный тип, описывающий внешний интерфейс репозитория для модели отзыва о продавце.
    /// </summary>
    public interface ISellerReviewRepository
    {
        /// <summary>
        /// Получение всех отзывов о продавце, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns>Выстроенное в оптимизированный запрос, перечисление из отзывов о продавце.</returns>
        public Task<IQueryable<SellerReviewResponseInfo>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение отзыва о продавце по идентификатору, асинхронно.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Информации об отзыве о продавце</returns>
        public Task<SellerReviewResponseInfo> GetByIdAsync(Guid id, CancellationToken cancelToken = default);
        #region to redact
        ///// <summary>
        ///// Получение всех отзывов о продавце, согласованных с фильтром, асинхронно.
        ///// </summary>
        ///// <param name="predicateFilter">Предикат, создающий условия для фильтрации отзывов о продавце.</param>
        ///// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        ///// <returns>Выстроенное в оптимизированный запрос, перечисление из отзывов о продавце, согласованных с <paramref name="predicateFilter"/></returns>
        //public Task<IQueryable<SellerReviewResponseInfo>> GetAllFiltred(Func<CreateSellerReviewRequest,bool> predicateFilter, CancellationToken cancelToken = default); 
        #endregion
        /// <summary>
        /// Добавление нового отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToAdd"></param>
        /// <param name="cancelToken"></param>
        public Task AddAsync(CreateSellerReviewRequest sReviewToAdd,CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление существующего отзыва о продавце,асинхронно.
        /// </summary>
        /// <param name="sReviewToDelete">Отзыв о продавце для добавления.</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи.</param>
        public Task DeleteAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление существующего отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewId">Идентификатор отзыва о продавце</param>
        /// <param name="sReviewToUpdate">Отзыв о продавце для обновления</param>
        /// <param name="cancelToken">Жетон для отмены</param>
        public Task UpdateAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default);
    }
}
