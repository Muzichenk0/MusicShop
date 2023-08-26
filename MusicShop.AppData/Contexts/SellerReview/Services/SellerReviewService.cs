
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.Contracts.SellerReview;

namespace MusicShop.AppData.Contexts.SellerReview.Services
{
    public class SellerReviewService : ISellerReviewService
    {
        private readonly ISellerReviewRepository _repository;
        public SellerReviewService(ISellerReviewRepository repository) => _repository = repository;

        public async Task CreateReviewAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default)
            => await _repository.AddAsync(sReviewToAdd, cancelToken);

        public async Task DeleteReviewAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default)
            => await _repository.DeleteAsync(sReviewToDelete, cancelToken);

        public async Task UpdateReviewAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default)
            => await _repository.UpdateAsync(sReviewId,sReviewToUpdate,cancelToken);

        public async Task<IQueryable<SellerReviewResponseInfo>> GetAllReviewsAsync(CancellationToken cancelToken = default)
            => await _repository.GetAllAsync(cancelToken);

        public async Task<SellerReviewResponseInfo> GetReviewByIdAsync(Guid id, CancellationToken cancelToken = default)
            => await _repository.GetByIdAsync(id,cancelToken);
    }
}
