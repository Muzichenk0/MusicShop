

using MusicShop.Contracts.SellerReview;

namespace MusicShop.AppData.Contexts.SellerReview.Services
{
    /// <summary>
    /// Абстрактный тип, описывающий внешний интерфейс модели сервиса, для отзывов о покупателе.
    /// </summary>
    public interface ISellerReviewService
    {
        /// <summary>
        /// Получение всех отзывов о продавце, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Выстроенное в оптимизированный запрос, перечисление из <see cref="SellerReviewResponseInfo"/> </returns>
        public Task<IQueryable<SellerReviewResponseInfo>> GetAllReviewsAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение отзыва о продавце, через идентификатор, асинхронно.
        /// </summary>
        /// <param name="id">Идентификатор отзыва о продавце</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Экземпляр <see cref="SellerReviewResponseInfo"/>, чей ID согласован с <paramref name="id"/></returns>
        public Task<SellerReviewResponseInfo> GetReviewByIdAsync(Guid id, CancellationToken cancelToken = default);
        /// <summary>
        /// Создание отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToAdd">Информация об отзыве о продавце для создания</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task CreateReviewAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Создание отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToDelete">Информация об отзыве о продавце для удаления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task DeleteReviewAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewId">Идентификатор отзыва о продавце</param>
        /// <param name="sReviewToUpdate">Информация об отзыве о продавце для обновления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task UpdateReviewAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default);
    }
}
