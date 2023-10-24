using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.Contracts.SellerReview;
using MusicShop.Infrastructure.Repositories.Base;
using System.Text.Json;

namespace MusicShop.DataAccess.Contexts.SellerReview
{
    /// <summary>
    /// Модель, реализующая внешний интерфейс для модели - репозиторий отзыва о продавце, описанный в  <see cref="ISellerReviewRepository"/>
    /// </summary>
    public class SellerReviewRepository : ISellerReviewRepository
    {
        private readonly IRepository<Domain.Models.User.User> _userRepository;
        private readonly IRepository<Domain.Models.Review.SellerReview> _sReviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SellerReviewRepository(
            ILogger<SellerReviewRepository> logger,
            IMapper mapper,
            IRepository<Domain.Models.Review.SellerReview> sReviewRepository,
            IRepository<Domain.Models.User.User> userRepository)
        {
            _logger = logger;
            _sReviewRepository = sReviewRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        ///<inheritdoc/>
        public async Task<Guid> AddAsync(CreateSellerReviewRequest sReviewToAdd, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToAdd)} trying to be added into database");

            var currentReview = _mapper.Map<Domain.Models.Review.SellerReview>(sReviewToAdd);

            await _sReviewRepository.AddAsync(_mapper.Map<Domain.Models.Review.SellerReview>(sReviewToAdd), cancelToken);

            await CountSellerRepAsync((Guid)currentReview.UserId!, cancelToken);

            return currentReview.Id;
        }
        public async Task<IQueryable<SellerReviewInfoResponse>> GetAllFilteredAsync(Func<object, bool> predicate, CancellationToken cancelToken = default)
        {
            return (await _sReviewRepository.GetAllFilteredAsync(predicate, cancelToken))
               .Select(review => _mapper.Map<SellerReviewInfoResponse>(review));
        }
        ///<inheritdoc/>
        public async Task DeleteAsync(DeleteSellerReviewRequest sReviewToDelete, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToDelete)} trying to be deleted from database");

            var foundReview = (await _sReviewRepository.GetByIdAsync(sReviewToDelete.Id));
      
            await CountSellerRepAsync((Guid)foundReview.UserId!, cancelToken);
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
        ///<inheritdoc/>
        public async Task<SellerReviewInfoResponse> GetByIdAsync(Guid id, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"seller review with id - {id} trying to be added into database");
            return _mapper.Map<SellerReviewInfoResponse>(await _sReviewRepository.GetByIdAsync(id, cancelToken));
        }
        ///<inheritdoc/>
        public async Task UpdateAsync(Guid sReviewId, UpdateSellerReviewRequest sReviewToUpdate, CancellationToken cancelToken = default)
        {
            Domain.Models.Review.SellerReview review = await _sReviewRepository.GetByIdAsync(sReviewId);

            await _sReviewRepository
                .UpdateAsync(_mapper.Map(sReviewToUpdate, review), cancelToken);

            
            await CountSellerRepAsync((Guid)review.UserId!, cancelToken);
        }
        ///<inheritdoc/>
        public async Task CountSellerRepAsync(Guid sellerId, CancellationToken cancelToken = default)
        {
            var sellerUser = (await _userRepository.GetAllAsync(cancelToken))
                .Include(u => u.GainedReviews)
                .First(u => u.Id == sellerId);

            double overallRating = 0;
            int reviewsCount = sellerUser.GainedReviews is null ? 0 : sellerUser.GainedReviews.Count();
            if (reviewsCount > 0)
                foreach (double rating in sellerUser.GainedReviews!.Select(review => review!.Rating))
                    overallRating += rating;

            sellerUser.Rating = (overallRating == 0 || reviewsCount == 0) ? 0 : overallRating / reviewsCount;
            await _userRepository.UpdateAsync(sellerUser, cancelToken);
        }
    }
}
