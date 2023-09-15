
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.Contracts.SellerReview;

namespace MusicShop.AppData.Contexts.SellerReview.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис отзыва о продавце.
    /// </summary>
    public class SellerReviewService : ISellerReviewService
    {
        private readonly ISellerReviewRepository _repository;
        public SellerReviewService(ISellerReviewRepository repository)
            => _repository = repository;
        ///<inheritdoc/>
        public Task CreateReviewAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default)
            => _repository.AddAsync(sReviewToAdd, cancelToken);
        ///<inheritdoc/>
        public Task DeleteReviewAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default)
            => _repository.DeleteAsync(sReviewToDelete, cancelToken);
        ///<inheritdoc/>
        public Task UpdateReviewAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default)
            => _repository.UpdateAsync(sReviewId,sReviewToUpdate,cancelToken);
        ///<inheritdoc/>
        public Task<IQueryable<SellerReviewInfoResponse>> GetAllReviewsAsync(CancellationToken cancelToken = default)
            => _repository.GetAllAsync(cancelToken);
        ///<inheritdoc/>
        public Task<SellerReviewInfoResponse> GetReviewByIdAsync(Guid id, CancellationToken cancelToken = default)
            => _repository.GetByIdAsync(id,cancelToken);
    }
}
