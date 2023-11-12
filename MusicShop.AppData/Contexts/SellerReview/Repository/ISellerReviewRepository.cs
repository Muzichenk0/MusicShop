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
        public Task<IQueryable<SellerReviewInfoResponse>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение отзыва о продавце по идентификатору, асинхронно.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Информации об отзыве о продавце</returns>
        public Task<SellerReviewInfoResponse> GetByIdAsync(Guid id, CancellationToken cancelToken = default);
        /// <summary>
        /// Добавление нового отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToAdd"></param>
        /// <param name="cancelToken"></param>
        /// <returns>ID созданного отзыва о продавце</returns>
        public Task<Guid> AddAsync(CreateSellerReviewRequest sReviewToAdd,CancellationToken cancelToken = default);
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
        /// <summary>
        /// Подсчет рейтинга у продавца из текущего отзыва, асинхронно.
        /// </summary>
        /// <param name="sellerId">Уникальный идентификатЫор продавца</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task CountSellerRepAsync(Guid sellerId, CancellationToken cancelToken = default);
    }
}
