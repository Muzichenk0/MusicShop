
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.Contracts.SellerReview;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.SellerReview
{
    public class SellerReviewRepository : ISellerReviewRepository
    {
        private readonly IRepository<Domain.Models.Review.SellerReview> _sReviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SellerReviewRepository(ILogger<SellerReviewRepository> logger, IRepository<Domain.Models.Review.SellerReview> sReviewRepository)
        {
            _logger = logger;
            _sReviewRepository = sReviewRepository;
        }
        public Task AddAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default)
            => _sReviewRepository.AddAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToAdd), cancelToken);

        public Task DeleteAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default)
            => _sReviewRepository.DeleteAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToDelete), cancelToken);

        public async Task<IQueryable<SellerReviewResponseInfo>> GetAllAsync(CancellationToken cancelToken = default)
            => (await _sReviewRepository.GetAllAsync(cancelToken))
            .Select(r => _mapper.Map<SellerReviewResponseInfo>(r))
            .AsQueryable();

        #region to redact
        //public async Task<IQueryable<SellerReviewResponseInfo>> GetAllFiltred(Func<Domain.Models.Review.SellerReview, bool> predicateFilter, CancellationToken cancelToken = default)
        //    => (await _sReviewRepository.GetAllFilteredAsync(predicateFilter, cancelToken))
        //    .Select(r => _mapper.Map<SellerReviewResponseInfo>(r))
        //    .AsQueryable(); 
        #endregion

        public async Task<SellerReviewResponseInfo> GetByIdAsync(Guid id, CancellationToken cancelToken = default)
            => _mapper.Map<SellerReviewResponseInfo>(await _sReviewRepository.GetByIdAsync(id, cancelToken));

        public Task UpdateAsync(UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default)
            => _sReviewRepository.UpdateAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToUpdate), cancelToken);

    }
}
