
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.Contracts.SellerReview;
using MusicShop.Infrastructure.Repositories.Base;
using System.Text.Json;

namespace MusicShop.DataAccess.Contexts.SellerReview
{
    /// <summary>
    /// Модель, реализующая внешний интерфейс для модели - репозиторий отзыва о продавце, описанный в  <see cref="ISellerReviewRepository"/>.
    /// </summary>
    public class SellerReviewRepository : ISellerReviewRepository
    {
        private readonly IRepository<Domain.Models.Review.SellerReview> _sReviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SellerReviewRepository(ILogger<SellerReviewRepository> logger, IMapper mapper, IRepository<Domain.Models.Review.SellerReview> sReviewRepository)
        {
            _logger = logger;
            _sReviewRepository = sReviewRepository;
            _mapper = mapper;
        }
        ///<inheritdoc/>
        public Task AddAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToAdd)} trying to be added into database");

            return _sReviewRepository.AddAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToAdd), cancelToken);
        }
        ///<inheritdoc/>
        public Task DeleteAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToDelete)} trying to be deleted from database");

            return _sReviewRepository.DeleteAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToDelete), cancelToken);
        }
        ///<inheritdoc/>
        public async Task<IQueryable<SellerReviewInfoResponse>> GetAllAsync(CancellationToken cancelToken = default)
        {
            IQueryable<Domain.Models.Review.SellerReview> sReviews = await _sReviewRepository.GetAllAsync(cancelToken);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviews)} trying to be taken from database");

            return sReviews
            .Select(r => _mapper.Map<SellerReviewInfoResponse>(r))
            .AsQueryable();
        }

        #region to redact
        //public async Task<IQueryable<SellerReviewResponseInfo>> GetAllFiltred(Func<Domain.Models.Review.SellerReview, bool> predicateFilter, CancellationToken cancelToken = default)
        //    => (await _sReviewRepository.GetAllFilteredAsync(predicateFilter, cancelToken))
        //    .Select(r => _mapper.Map<SellerReviewResponseInfo>(r))
        //    .AsQueryable(); 
        #endregion
        ///<inheritdoc/>
        public async Task<SellerReviewInfoResponse> GetByIdAsync(Guid id, CancellationToken cancelToken = default)
        {
            return _mapper.Map<SellerReviewInfoResponse>(await _sReviewRepository.GetByIdAsync(id, cancelToken));
            //_logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToAdd)} trying to be added into database");
        }
        ///<inheritdoc/>
        public async Task UpdateAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default)
        {
            Domain.Models.Review.SellerReview review = await _sReviewRepository.GetByIdAsync(sReviewId);
            await _sReviewRepository
                .UpdateAsync(_mapper.Map(sReviewToUpdate, review), cancelToken);
        }
    }
}
