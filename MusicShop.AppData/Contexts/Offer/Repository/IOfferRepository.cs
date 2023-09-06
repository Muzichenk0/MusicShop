using MusicShop.Contracts.Offer;

namespace MusicShop.AppData.Contexts.Offer.Repository
{
    /// <summary>
    /// Абстрактный тип, описывающий внешний интерфейс для модели - репозитория предложения.
    /// </summary>
    public interface IOfferRepository
    {
        /// <summary>
        /// Получение всех предложений, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной, параллельной задачи</param>
        /// <returns>Сформированное в оптимизированный запрос, перечисление из экземпляров <see cref="OfferInfoResponse"/></returns>
        public Task<IQueryable<OfferInfoResponse>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение предложения по идентификатору, асинхронно.
        /// </summary>
        /// <param name="offerId">Уникальный идентификатор предложения</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной, параллельной задачи</param>
        public Task<OfferInfoResponse> GetByIdAsync(Guid offerId, CancellationToken cancelToken = default);
        /// <summary>
        /// Добавление нового предложения, асинхронно.
        /// </summary>
        /// <param name="offerToAdd">Предложение для добавления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной, параллельной задачи</param>
        public Task AddAsync(CreateOfferRequest offerToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление существующего предложения, асинхронно.
        /// </summary>
        /// <param name="offerToDelete">Предложение для удаления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной, параллельной задачи</param>
        public Task DeleteAsync(DeleteOfferRequest offerToDelete, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление информации об существующем предложении, асинхронно.
        /// </summary>
        /// <param name="offerId">Уникальный идентификатор предложения</param>
        /// <param name="offerToUpdate">Предложение для обновления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной, параллельной задачи</param>
        public Task UpdateAsync(Guid offerId, UpdateOfferRequest offerToUpdate, CancellationToken cancelToken = default);
    }
}
